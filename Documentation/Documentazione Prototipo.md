# Documentazione Prototipo (ITA)

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Indice</h2></summary>
  <ol>
    <li><a href="#obbiettivo-prototipo">Obbiettivo Prototipo</a></li>
    <li><a href="#principali-funzionalità">Principali Funzionalità</a></li>
    <li><a href="#flusso-di-esecuzione">Flusso di esecuzione</a></li>
    <li>
		<a href="#componenti">Componenti</a>
		<ul>
			<li><a href="#file-gamecs">File Game.cs</a></li>
		</ul>
	</li>
  </ol>
</details>

Il prototipo consiste in un piccolo gioco multigiocatore in cui ogni giocatore muove il proprio personaggio 
capsula e può interagire con i vari oggetti di scena.


## Obbiettivo Prototipo

L'obbiettivo del progetto è quello di realizzare un gameplay basilare, con movimento dei personaggi e 
piccole interazioni con l'ambiente di gioco, sfruttando i package forniti dall'architettura Unity DOTS. 
In particolare, sono stati utilizzati i seguenti package:
* Entities, per realizzare il modello basato su Entità, Componenti e Sistemi (ECS).
* NetCode, per realizzare la parte legata al networking, ovvero le connessioni dei giocatori (client) al server di gioco e la comunicazione fra questi.
* Physics, per realizzare le meccaniche legate alla fisica (entità statiche/dinamiche, sistema delle collisioni, ecc.).


## Principali Funzionalità

* Movimento del personaggio capsula.
* Camera follow in terza persona.
* Portali cambia-colore.
* Teletrasporti.
* Raccolta oggetti "Collectibles".
* Simulazione fisica con entità di forme e proprietà fisiche differenti.


## Flusso di esecuzione

Il flusso di esecuzione del prototipo è il seguente:
1. All'avvio dell'applicazione viene eseguito il sistema Game, contenuto in Game.cs. Questo sistema realizza
	la connessione dei client al server, differenziando l'esecuzione del server, il quale si mette in ascolto
	per le connessioni, da quella dei client, che si connettono al server.
2. I client eseguono il sistema GoInGameClientSystem, che invia una richiesta al server per entrare in gioco
	e iniziare a inviare comandi e ricevere snapshot (ovvero gli aggiornamenti dello stato di gioco).
3. Il server esegue il sistema GoInGameServerSystem, che riceve le richieste di entrare in gioco e per
	ciascun giocatore abilita la comunicazione tramite comandi e snapshot, e genera un personaggio capsula.
4. input system
5. movement system
6. aggiornamento dei system che realizzano le varie funzionalità.


## Componenti

NB: i pezzi di codice mostrati sono stati ritagliati per mostrare solo le parti fondamentali spiegate
nel testo.

### File <a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Game.cs">Game.cs</a>

Il File Game.cs contiene la *logica per realizzare la connessione*. In particolare al suo interno c'è un 
sistema **Game** che controlla se il codice che esegue è quello di un client o di un server, svolgendo 
rispettivamente connect o listen.<br/>
Una volta che client e server sono connessi, è necessario indicare a NetCode che i client sono pronti a 
inviare comandi e ricevere snapshot dal server: appena la connessione viene stabilita, lato client inizia ad 
eseguire il sistema **GoInGameClientSystem**, che invia una RPC al server; lato server inizia ad eseguire il 
sistema **GoInGameServerSystem** che riceve la RPC e marchia il client come "in gioco", aggiungendo il 
componente **NetworkStreamInGame** all'entità che rappresenta la connessione e creando una personaggio 
capsula per il giocatore corrispondente al client.

#### Struttura EnableGame

Dichiariamo la struttura **EnableGame** che ci servirà più avanti per indicare che i client o il server sono
pronti a stabilire la connessione ed entrare in gioco.

#### Sistema Game

[UpdateInWorld(UpdateInWorld.TargetWorld.Default)] indica che il sistema Game dev'essere eseguito nel mondo 
di default, in quanto questo mondo è sempre presente perché istanziato automaticamente da Unity.

Poiché il codice del sistema Game realizza la connessione, dev'essere eseguito una sola volta per run
dell'applicazione. Dunque, utilizziamo un ulteriore singleton **InitGameComponent**, per indicare quando il 
codice di questo sistema è già stato eseguito una volta: nella OnCreate() usiamo il metodo 
**RequireSingletonForUpdate<>()** per indicare l'entità che dev'essere presente affinché OnUpdate() venga
chiamata; dopodiché creiamo l'entità avente questo componente; infine nella OnUpdate() rimuoviamo tale
entità, così Unity non chiama più OnUpdate() di Game.
<pre>
protected override void OnCreate()
{
	RequireSingletonForUpdate<InitGameComponent>();
	EntityManager.CreateEntity(typeof(InitGameComponent));
}
</pre>

La OnUpdate() itera su tutti i mondi presenti nell'applicazione e, dopo aver ottenuto il sistema
**NetworkStreamReceiveSystem** (che espone i metodi Connect e Listen), controlliamo se ci troviamo in un
client o in un server:
* Nel caso l'applicazione sia un client, sarà presente il mondo ClientWorld, al cui interno vi sarà il
gruppo di sistemi **ClientSimulationSystemGroup**. Dunque creiamo l'entità singleton **EnableGame** e
facciamo una connect a localhost:7979.
* Nel caso l'applicazione sia un server, sarà presente il mondo ServerWorld, al cui interno vi sarà il
gruppo di sistemi **ServerSimulationSystemGroup**. Dunque creiamo l'entità singleton **EnableGame** e
facciamo una listen sulla porta 7979.
<pre>
protected override void OnUpdate()
{
    EntityManager.DestroyEntity(GetSingletonEntity<InitGameComponent>());
    foreach (var world in World.All)
    {
        var network = world.GetExistingSystem<NetworkStreamReceiveSystem>();
        if (world.GetExistingSystem<ClientSimulationSystemGroup>() != null)
        {
            world.EntityManager.CreateEntity(typeof(EnableGame));
            NetworkEndPoint ep = NetworkEndPoint.LoopbackIpv4;
            ep.Port = 7979;
            ep = NetworkEndPoint.Parse(ClientServerBootstrap.RequestedAutoConnect, 7979);

            network.Connect(ep);
        }
        else if (world.GetExistingSystem<ServerSimulationSystemGroup>() != null)
        {
            world.EntityManager.CreateEntity(typeof(EnableGame));
            NetworkEndPoint ep = NetworkEndPoint.AnyIpv4;
            ep.Port = 7979;

            network.Listen(ep);
        }
    }
}
</pre>

#### Struttura GoInGameRequest

Poiché non è stato aggiunto il componente **NetworkStreamInGame** all'entità che rappresenta la connessione 
fra un client ed il server, questi non possono comunicare inviando comandi o snapshot. Quindi, utilizziamo 
una RPC NetCode (IRpcCommand) per notificare al server che il client è pronto ad entrare in gioco, così il 
server può marcare la connessione e avviare la comunicazione.<br/>
Come spiegato nella documentazione di <a href="https://docs.unity3d.com/Packages/com.unity.netcode@0.6/manual/rpcs.html">NetCode</a>, 
per inviare una RPC è necessario creare un entità ed aggiungervi il comando RPC creato ed il componente
SendRpcCommandRequestComponent, che innesca il sistema di invio della RPC di Unity.

#### Sistema GoInGameClientSystem

L'attributo [UpdateInGroup(typeof(ClientSimulationSystemGroup))] indica che questo sistema dev'essere
aggiornato solo nei client, all'interno del gruppo ClientSimulationSystemGroup.<br/>
Vogliamo che questo sistema esegua una sola volta, quando il client deve entrare in gioco, per la precisione
dopo la connessione con il server, ma prima che venga avviata la comunicazione via comandi e snapshot.
Dunque, richiediamo che sia presente il singleton EnableGame e che l'entità rappresentante la connessione
(che possiede il componente **NetworkIdComponent**), non abbia **NetworkStreamInGame**.
<pre>
protected override void OnCreate()
{
    RequireSingletonForUpdate<EnableGame>();
    RequireForUpdate(GetEntityQuery(ComponentType.ReadOnly<NetworkIdComponent>(), ComponentType.Exclude<NetworkStreamInGame>()));
}
</pre>

Dopodiché nella OnUpdate(), iteriamo su tutte le entità che possiedono **NetworkIdComponent** ma non hanno
**NetworkStreamInGame**, ovvero l'entità della connessione. Dunque, utilizzando un command buffer, seguiamo 
la procedura per inviare la RPC: creiamo un'entità, vi aggiungiamo il comando RPC, ed infine aggiungiamo il
componente **SendRpcCommandRequestComponent** indicando la connessione target.
<pre>
protected override void OnUpdate()
{
    var commandBuffer = new EntityCommandBuffer(Allocator.Temp);
    Entities.WithNone<NetworkStreamInGame>().ForEach((Entity ent, in NetworkIdComponent id) =>
    {
        commandBuffer.AddComponent<NetworkStreamInGame>(ent);
        var req = commandBuffer.CreateEntity();
        commandBuffer.AddComponent<GoInGameRequest>(req);
        commandBuffer.AddComponent(req, new SendRpcCommandRequestComponent { TargetConnection = ent });
    }).Run();
    commandBuffer.Playback(EntityManager);
    commandBuffer.Dispose();
}
</pre>

#### Sistema GoInGameServerSystem

L'attributo [UpdateInGroup(typeof(ServerSimulationSystemGroup))] indica che questo sistema dev'essere
aggiornato solo nel server.<br/>
Vogliamo che questo sistema esegua solo quando, dopo che è stato aggiunto il singleton EnableGame, arriva 
una richiesta di RPC da un client. Dunque, richiediamo che sia presente EnableGame e che vi sia un'entità
avente come componenti il nostro comando RPC e **ReceiveRpcCommandRequestComponent**.
<pre>
protected override void OnCreate()
{
    RequireSingletonForUpdate<EnableGame>();
    RequireForUpdate(GetEntityQuery(ComponentType.ReadOnly<GoInGameRequest>(), ComponentType.ReadOnly<ReceiveRpcCommandRequestComponent>()));
}
</pre>

Nella OnUpdate() otteniamo la lista dei ghost prefab, ovvero i networked object. Nel nostro prototipo
l'unico ghost presente è la PlayerCapsule, ovvero il personaggio che ciascun giocatore controlla e muove per
la mappa. Poiché in futuro questa lista potrebbe essere ampliata, controlliamo comunque che il ghost sia
quello della capsula, ovvero se possiede il componente PlayerMovementSpeed, e lo salviamo in una
variabile.<br/>
Dopodiché otteniamo la lista dei **NetworkIdComponent** delle connessioni, salvandola in networkIdFromEntity,
ovvero un container *dictionary-like*. Tramite questo container possiamo assegnare il rispettivo id della 
connessione al componente **GhostOwnerComponent** del ghost di ciascun client. Questa è un'operazione 
fondamentale che bisogna fare a runtime, in quanto prima non è possibile conoscere a chi apparterrà un certo
ghost.
<br/>
Dunque iteriamo su tutte le entità che corrispondono a richieste RPC (aventi dunque GoInGameRequest e
ReceiveRpcCommandRequestComponent). Poiché nella richiesta è presente l'entità della connessione sorgente
da cui è partita la RPC, possiamo utilizzarla per aggiungervi il componente **NetworkStreamInGame** e 
iniziare la comunicazione via comandi e snapshot.
<br/>
Fatto questo, istanziamo la capsula del giocatore e aggiorniamo il NetworkId del proprietario di tale ghost.
<br/>
Infine, aggiungiamo alla capsula il buffer su cui verranno accumulati gli input del giocatore, ed alla
connessione il componente **CommandTargetComponent** che servirà al sistema di gestione degli input
per capire a quale ghost applicare gli input ricevuti dal giocatore. Inoltre, distruggiamo l'entità della
richiesta RPC altrimenti il sistema continua ad eseguire all'infinito.
<br/>
Ora è tutto impostato correttamente per permettere al client di accumulare input ed inviarli al server 
sottoforma di comandi, ed al server di ricevere questi comandi, applicarli nella propria simulazione ed
inviare le snapshot (ovvero gli aggiornamenti dello stato di gioco) al client.
<pre>
protected override void OnUpdate()
{
    var ghostCollection = GetSingletonEntity<GhostPrefabCollectionComponent>();
    var prefab = Entity.Null;
    var prefabs = EntityManager.GetBuffer<GhostPrefabBuffer>(ghostCollection);
    for (int ghostId = 0; ghostId < prefabs.Length; ++ghostId)
    {
        if (EntityManager.HasComponent<PlayerMovementSpeed>(prefabs[ghostId].Value))
            prefab = prefabs[ghostId].Value;
    }

    var commandBuffer = new EntityCommandBuffer(Allocator.Temp);
    var networkIdFromEntity = GetComponentDataFromEntity<NetworkIdComponent>(true);
    Entities.WithReadOnly(networkIdFromEntity).ForEach((Entity reqEnt, in GoInGameRequest req, in ReceiveRpcCommandRequestComponent reqSrc) =>
    {
        commandBuffer.AddComponent<NetworkStreamInGame>(reqSrc.SourceConnection);
        UnityEngine.Debug.Log(String.Format("Server setting connection {0} to in game", networkIdFromEntity[reqSrc.SourceConnection].Value));

        var player = commandBuffer.Instantiate(prefab); // spawn capsula per il giocatore
        commandBuffer.SetComponent(player, new GhostOwnerComponent { NetworkId = networkIdFromEntity[reqSrc.SourceConnection].Value });

        commandBuffer.AddBuffer<PlayerInput>(player);
        commandBuffer.SetComponent(reqSrc.SourceConnection, new CommandTargetComponent { targetEntity = player });

        commandBuffer.DestroyEntity(reqEnt);
    }).Run();
    commandBuffer.Playback(EntityManager);
    commandBuffer.Dispose();
}
</pre>


### File PlayerMovementSystem


### File PlayerInputSystem
