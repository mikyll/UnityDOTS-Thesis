
# Documentazione Prototipo (ITA)

Il prototipo consiste in un piccolo gioco multigiocatore in cui ogni giocatore muove il proprio personaggio 
capsula e può interagire con i vari oggetti di scena. È stato realizzato interamente con i package forniti 
da DOTS.
<br/>
<p align="center">
<a href="https://github.com/mikyll/TesiUnityDOTS">Home page</a>
·
<a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Prototype%20Documentation.md">English version</a>
</p>

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Indice</h2></summary>
  <ol>
    <li><a href="#obbiettivo-prototipo">Obbiettivo Prototipo</a></li>
    <li><a href="#principali-funzionalità">Principali Funzionalità</a></li>
    <li><a href="#build-applicazione-standalone">Build Applicazione Standalone</a></li>
    <li><a href="#flusso-di-esecuzione">Flusso di esecuzione</a></li>
    <li>
		<a href="#codice">Codice</a>
		<ul>
			<li><a href="#file-gamecs">File Game.cs</a></li>
			<li><a href="#file-playerinputsystemcs">File PlayerInputSystem.cs</a></li>
			<li><a href="#file-playermovementsystemcs">File PlayerMovementSystem.cs</a></li>
		</ul>
	</li>
  </ol>
</details>

## Obbiettivo Prototipo

L'obbiettivo del prototipo è quello di realizzare un gameplay basilare, con movimento dei personaggi e 
piccole interazioni con l'ambiente di gioco, sfruttando i package forniti dall'architettura Unity DOTS. 
In particolare, sono stati utilizzati i seguenti package:
* Entities, per realizzare il modello basato su Entità, Componenti e Sistemi (ECS).
* NetCode, per realizzare la parte legata al networking, ovvero le connessioni dei giocatori (client) al 
server di gioco e la comunicazione fra questi.
* Physics, per realizzare le meccaniche legate alla fisica (entità statiche/dinamiche, sistema delle 
collisioni, ecc.).


## Principali Funzionalità

<table>
	<tr>
		<td><b>Funzionalità</b></td>
		<td><b>File</b></td>
		<td><b>Dimostrazione</b></td>
	</tr>
	<tr>
		<td>Accumulo degli input e movimento personaggio capsula</td>
		<td><a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PlayerInputSystem.cs">PlayerInputSystem.cs</a><br/>
		<a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PlayerMovementSystem.cs">PlayerMovementSystem.cs</a></td>
		<td><img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Images/GIF_Movement.gif" alt="MovimentoGIF"/></td>
	</tr>
	<tr>
		<td>Camera follow in terza persona</td>
		<td><a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/CameraFollowPlayerSystem.cs">CameraFollowPlayerSystem.cs</a></td>
		<td><img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Images/GIF_CameraFollow.gif" alt="CameraFollowGIF"/></td>
	</tr>
	<tr>
		<td>Portali cambia-colore</td>
		<td><a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PersistentChangeMaterialOnTriggerSystem.cs">PersistentChangeMaterialOnTriggerSystem.cs</a><br/>
		<a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/TemporaryChangeMaterialOnTriggerSystem.cs">TemporaryChangeMaterialOnTriggerSystem.cs</a></td>
		<td><img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Images/GIF_ChangeMaterialPortals.gif" alt="PortaliColoreGIF"/></td>
	</tr>
	<tr>
		<td>Teletrasporti</td>
		<td><a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/TeleportSystem.cs">TeleportSystem.cs</a></td>
		<td><img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Images/" alt="TeletrasportoGIF"/></td>
	</tr>
	<tr>
		<td>Raccolta oggetti "collectibles"</td>
		<td></td>
		<td><img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Images/" alt="CollectiblesGIF"/></td>
	</tr>
</table>

* Movimento del personaggio capsula.
* Camera follow in terza persona.
* Portali cambia-colore.
* Teletrasporti.
* Raccolta oggetti "Collectibles".
* Simulazione fisica con entità di forme e proprietà fisiche differenti.


## Build Applicazione Standalone
Per eseguire la <a href="https://docs.unity3d.com/Packages/com.unity.entities@0.17/manual/install_setup.html#standalone-builds">build</a> di un'applicazione Unity realizzata usando DOTS, è necessario utilizzare i package Platforms (com.unity.platforms.\*). In particolare, nel caso di un'<a href="https://docs.unity3d.com/Packages/com.unity.netcode@0.6/manual/client-server-worlds.html#standalone-builds">applicazione multiplayer</a>, NetCode utilizza la proprietà <i>Server Build</i> in Build Settings e gli scripting define symbols in Project Settings > Player per capire che tipo di applicazione buildare (solo client, solo server o scelta a runtime).
### Esempio Windows
1. Controllare che il package com.unity.platforms.windows sia presente nel PackageManager.
2. Creare una Configurazione di Build: Project Window > Create > Build > Windows Classic Build Configuration.
3. Selezionare la configurazione ed eseguire la build.
<p float="left">
<img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Images/WindowsBuild%20(1).png" alt="WindowsBuild (1)" width="50%"/>
<img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Images/WindowsBuild%20(2).png" alt="WindowsBuild (2)" width="45%"/>
</p>

## Flusso di Esecuzione

Il flusso di esecuzione del prototipo è il seguente:
1. All'avvio dell'applicazione viene eseguito il sistema Game, contenuto in Game.cs. Questo sistema realizza
	la connessione dei client al server, differenziando l'esecuzione del server, il quale si mette in ascolto
	per le connessioni, da quella dei client, che si connettono al server.
2. I client eseguono il sistema GoInGameClientSystem, che invia una richiesta al server per entrare in gioco
	e iniziare a inviare comandi e ricevere snapshot (ovvero gli aggiornamenti dello stato di gioco).
3. Il server esegue il sistema GoInGameServerSystem, che riceve le richieste di entrare in gioco e per
	ciascun giocatore abilita la comunicazione tramite comandi e snapshot, e genera un personaggio capsula.
4. L'applicazione, tramite il sistema PlayerInputSystem, controlla continuamente se il giocatore immette input 
	da tastiera e in caso li accumula in un buffer e li invia al server.
6. Il sistema PlayerMovementSystem applica gli input alle varie capsule, utilizzando la predizione lato client
	per rendere l'esecuzione più fluida e far percepire il meno possibile la latenza della rete.
8. Nel mentre si aggiornano anche gli altri sistemi che realizzano le varie funzionalità.


## Codice

NB: i pezzi di codice mostrati sono stati ritagliati per mostrare solo le parti fondamentali spiegate
nel testo.

### File <a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Game.cs">Game.cs</a>

Il file Game.cs contiene la *logica per realizzare la connessione*. In particolare al suo interno c'è un 
sistema **Game** che controlla se il codice che esegue è quello di un client o di un server, svolgendo 
rispettivamente connect o listen.<br/>
Una volta che client e server sono connessi, è necessario indicare a NetCode che i client sono pronti a 
inviare comandi e ricevere snapshot dal server: appena la connessione viene stabilita, lato client inizia ad 
eseguire il sistema **GoInGameClientSystem**, che invia una RPC al server; lato server inizia ad eseguire il 
sistema **GoInGameServerSystem** che riceve la RPC e marchia il client come "in gioco", aggiungendo il 
componente **NetworkStreamInGame** all'entità che rappresenta la connessione e creando una personaggio 
capsula per il giocatore corrispondente al client.

#### Struttura `EnableGame`

Dichiariamo la struttura **EnableGame** che ci servirà più avanti per indicare che i client o il server sono
pronti a stabilire la connessione ed entrare in gioco.

#### Sistema `Game`

[UpdateInWorld(UpdateInWorld.TargetWorld.Default)] indica che il sistema Game dev'essere eseguito nel mondo 
di default, in quanto questo mondo è sempre presente perché istanziato automaticamente da Unity.

Poiché il codice del sistema Game realizza la connessione, dev'essere eseguito una sola volta per run
dell'applicazione. Dunque, utilizziamo un ulteriore singleton **InitGameComponent**, per indicare quando il 
codice di questo sistema è già stato eseguito una volta: nella OnCreate() usiamo il metodo 
**RequireSingletonForUpdate<>()** per indicare l'entità che dev'essere presente affinché OnUpdate() venga
chiamata; dopodiché creiamo l'entità avente questo componente; infine nella OnUpdate() rimuoviamo tale
entità, così Unity non chiama più OnUpdate() del sistema Game.
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

#### Struttura `GoInGameRequest`

Poiché non è stato aggiunto il componente **NetworkStreamInGame** all'entità che rappresenta la connessione 
fra un client ed il server, questi non possono comunicare inviando comandi o snapshot. Quindi, utilizziamo 
una RPC NetCode (IRpcCommand) per notificare al server che il client è pronto ad entrare in gioco, così il 
server può marcare la connessione e avviare la comunicazione.<br/>
Come spiegato nella documentazione di <a href="https://docs.unity3d.com/Packages/com.unity.netcode@0.6/manual/rpcs.html">NetCode</a>, 
per inviare una RPC è necessario creare un entità ed aggiungervi il comando RPC creato ed il componente
SendRpcCommandRequestComponent, che innesca il sistema di invio della RPC di Unity.

#### Sistema `GoInGameClientSystem`

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

#### Sistema `GoInGameServerSystem`

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


### File <a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PlayerMovementSystem.cs">PlayerInputSystem.cs</a>
Il file PlayerInputSystem.cs contiene la logica per l'accumulo degli input del giocatore. Essendo questo un gioco multiplayer, non basta semplicemente campionare l'input e usarlo direttamente, ma è necessario immagazzinarlo da qualche parte (una struttura <b><a href="https://docs.unity3d.com/Packages/com.unity.netcode@0.6/api/Unity.NetCode.ICommandData.html?q=ICommandData">ICommandData</a></b>) ed inviarlo al Server sotto forma di comando, così che anche lui possa applicarlo nella propria simulazione. Infatti, poiché NetCode si basa su un modello a server autoritativo, la simulazione viene eseguita sia su client che su server, ma il server ha l'autorità, ovvero la sua simulazione è sempre corretta ed il client deve correggere la propria in base a questa.

#### Struttura `PlayerInput`
La struttura PlayerInput implementa l'interfaccia ICommandData, ovvero l'interfaccia necessaria per realizzare un comando in NetCode. Questa non è altro che un <a href="https://docs.unity3d.com/Packages/com.unity.entities@0.17/manual/dynamic_buffers.html#:~:text=A%20DynamicBuffer%20is%20a%20type,the%20internal%20capacity%20is%20exhausted.">buffer dinamico</a> utilizzato per accumulare comandi da trasmettere attraverso una connessione. Infatti, questa interfaccia espone la proprietà Tick, che dev'essere specificata, in quanto indica il tick di esecuzione della simulazione in cui è stato campionato l'input, così che il server, quando lo riceverà, potrà applicarlo nello stesso momento del client, indipendentemente dalla latenza della rete. Il tick permette anche di sfruttare la <a href="https://docs.unity3d.com/Packages/com.unity.netcode@0.6/manual/prediction.html">predizione lato client</a> fornita da NetCode.<br/>
Nel nostro caso questa struttura contiene, oltre al tick, i campi horizontal e vertical, che indicano rispettivamente il movimento sull'asse x e sull'asse y.
<pre>
public struct PlayerInput : ICommandData
{
	public uint Tick { get; set; }
	public int horizontal;
	public int vertical;
}
</pre>

#### Sistema `PlayerInputSystem`
La raccolta degli input avviene tramite il sistema <b>PlayerInputSystem</b>, che esegue solo lato client. All'interno di questo, in OnCreate(), innanzitutto richiediamo che, affinché il sistema venga aggiornato, siano presenti il singleton <b>NetworkIdComponent</b> (che identifica una connessione, dunque un client) ed EnableGame (che indica che il gioco è iniziato). Poi salviamo in una variabile il gruppo di sistema <b>ClientSimulationSystemGroup</b>, in quanto da questo possiamo ottenere il tick del server (che aggiorna sempre ad un timestep fisso).
<pre>
ClientSimulationSystemGroup m_ClientSimulationSystemGroup;
protected override void OnCreate()
{
	RequireSingletonForUpdate<NetworkIdComponent>();
	RequireSingletonForUpdate<EnableGame>();
	m_ClientSimulationSystemGroup = World.GetExistingSystem<ClientSimulationSystemGroup>();
}
</pre>

La parte più complicata di questo sistema risiede nel metodo OnUpdate(): dopo aver ottenuto il singleton <b>CommandTargetComponent</b>, controlliamo che contenga il  riferimento all'entità capsula del giocatore. Poiché a runtime ci possono essere diversi giocatori, e di conseguenza diversi personaggi capsula, è necessario distinguere il client a cui appartengono. Il componente CommandTargetComponent serve proprio a questo: è un singleton, diverso per ogni client. Infatti, quando l'applicazione viene messa in esecuzione normalmente, è presente solo il World del client specifico, di conseguenza il singleton rappresenta l'entità ghost della capsula associata al client del mondo.
Però, poiché alla prima esecuzione questo componente non è inizializzato, dobbiamo gestire anche il caso in cui non contenga ancora l'entità. In questo caso semplicemente otteniamo l'id della connessione dal singleton NetworkIdComponent e, iterando su tutte le entità capsula, cerchiamo quella con il <b>NetworkId</b> (nel componente <b>GhostOwner</b>, che avevamo inizializzato in Game.cs) corrispondente. Una volta trovata, impostiamo il valore di targetEntity di CommandTargetComponent.
<pre>
var localInput = GetSingleton<CommandTargetComponent>().targetEntity; 
if (localInput == Entity.Null)
{
	var localPlayerId = GetSingleton<NetworkIdComponent>().Value;
	var commandBuffer = new EntityCommandBuffer(Allocator.Temp);
	var commandTargetEntity = GetSingletonEntity<CommandTargetComponent>();
	Entities.WithAll<PlayerMovementSpeed>().WithNone<PlayerInput>()
	.ForEach((Entity ent, ref GhostOwnerComponent ghostOwner) =>
	{
	if (ghostOwner.NetworkId == localPlayerId)
	{
		commandBuffer.AddBuffer<PlayerInput>(ent);
		commandBuffer.SetComponent(commandTargetEntity, new CommandTargetComponent { targetEntity = ent });
	}
	}).Run();
	commandBuffer.Playback(EntityManager);
	return;
}
</pre>

Fatto ciò possiamo finalmente campionare gli input: dopo aver aggiornato il tick del comando, con quello del server, ottenuto da ClientSimulationSystemGroup, impostiamo il valore di horizontal e vertical in base all'input ricevuto dall'utente. Infine, aggiungiamo l'input al buffer di comandi PlayerInput.
<pre>
var input = default(PlayerInput);
input.Tick = m_ClientSimulationSystemGroup.ServerTick;
if (Input.GetKey("a"))
	input.horizontal -= 1;
if (Input.GetKey("d"))
	input.horizontal += 1;
if (Input.GetKey("s"))
	input.vertical -= 1;
if (Input.GetKey("w"))
	input.vertical += 1;
var inputBuffer = EntityManager.GetBuffer<PlayerInput>(localInput);
inputBuffer.AddCommandData(input);
</pre>


### File <a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PlayerMovementSystem.cs">PlayerMovementSystem.cs</a>
Questo file contiene la logica per l'applicazione del movimento alle capsule dei giocatori, applicando la predizione. 

#### Sistema `PlayerInputSystem`
Questo sistema viene aggiornato all'interno del gruppo <b>GhostPredictionSystemGroup</b>, che permette di implementare la predizione lato client dei ghost.
In particolare, nella OnUpdate() otteniamo il tick di predizione da tale gruppo e iteriamo su tutte le entità capsule, inserendo nella lambda i componenti che ci serviranno.
Come prima cosa controlliamo se il codice della predizione dovrebbe eseguire, utilizzando il metodo <b>ShouldPredict()</b> per sapere se all'entità dev'essere applicata la predizione per il tick in questione. In caso affermativo, dal buffer PlayerInput otteniamo il comando relativo a tale tick, e applichiamo il movimento in base ai dati contenuti nel comando.
<pre>
var tick = m_GhostPredictionSystemGroup.PredictingTick;
var deltaTime = Time.DeltaTime;
Entities.ForEach((DynamicBuffer<PlayerInput> inputBuffer, ref PhysicsVelocity pv, in PredictedGhostComponent prediction, in PlayerMovementSpeed pms) =>
{
	if (!GhostPredictionSystemGroup.ShouldPredict(tick, prediction))
		return;
	PlayerInput input;
	inputBuffer.GetDataAtTick(tick, out input);
	var speed = pms.speed;
	
	if (input.horizontal > 0)
		pv.Linear.x += speed * deltaTime;
	if (input.horizontal < 0)
		pv.Linear.x -= speed * deltaTime;
	if (input.vertical > 0)
		pv.Linear.z += speed * deltaTime;
	if (input.vertical < 0)
		pv.Linear.z -= speed * deltaTime;
}).ScheduleParallel();
</pre>
