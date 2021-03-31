# Documentazione Prototipo (ITA)

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Obbiettivo Prototipo</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">Principali Funzionalità</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <!--<li><a href="#license">License</a></li>-->
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
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

* Portali cambia-colore.
* Teletrasporti.
* Raccolta oggetti "Collectibles".
* Simulazione fisica con entità di forme e proprietà fisiche differenti.
* Camera follow in terza persona.

## Spiegazione Codice ...

Flusso di esecuzione

### File <a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/DOTS%20Prototype/Assets/Scripts/Game.cs">Game.cs</a>

Il File Game.cs contiene la *logica per realizzare la connessione*. In particolare al suo interno c'è un sistema 
**Game** che controlla se il codice che esegue è quello di un client o di un server, svolgendo rispettivamente 
connect o listen.<br/>
Una volta che client e server sono connessi, è necessario indicare a NetCode che i client sono pronti a 
inviare comandi e ricevere snapshot dal server: appena la connessione viene stabilita, lato client inizia ad 
eseguire il sistema **GoInGameClientSystem**, che invia una RPC al server; lato server inizia ad eseguire il 
sistema **GoInGameServerSystem** che riceve la RPC e marchia il client come "in gioco", aggiungendo il 
componente **NetworkStreamInGame** all'entità che rappresenta la connessione.
<br/>
<br/>
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

	protected override void OnCreate()
    {
        RequireSingletonForUpdate<InitGameComponent>();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "Prototipo")
            return;
        // Create singleton, require singleton for update so system runs once
        EntityManager.CreateEntity(typeof(InitGameComponent));
    }

La OnUpdate() itera su tutti i mondi presenti nell'applicazione e, dopo aver ottenuto il sistema
**NetworkStreamReceiveSystem** (che espone i metodi Connect e Listen), controlliamo se ci troviamo in un
client o in un server:
* Nel caso l'applicazione sia un client, sarà presente il mondo ClientWorld, al cui interno vi sarà il
gruppo di sistemi **ClientSimulationSystemGroup**. Dunque creiamo l'entità singleton **EnableGame** e
facciamo una connect a localhost:7979.
* Nel caso l'applicazione sia un server, sarà presente il mondo ServerWorld, al cui interno vi sarà il
gruppo di sistemi **ServerSimulationSystemGroup**. Dunque creiamo l'entità singleton **EnableGame** e
facciamo una listen sulla porta 7979.

#### Struttura GoInGameRequest

Poiché non è stato aggiunto il componente NetworkStreamInGame all'entità che rappresenta la connessione fra
un client ed il server, questi non possono comunicare inviando comandi o snapshot. Quindi, utilizziamo una 
RPC per notificare al server che il client è pronto ad entrare in gioco, così il server può marcare la
connessione e avviare la comunicazione.




### File
