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

### File Game.cs

Il File Game.cs contiene la logica per realizzare la connessione. In particolare al suo interno c'è un sistema 
**Game** che controlla se il codice che esegue è quello di un client o di un server, svolgendo rispettivamente 
connect o listen.<br/>
Una volta che client e server sono connessi, è necessario indicare a NetCode che i client sono pronti a 
inviare comandi e ricevere snapshot dal server: appena la connessione viene stabilita, lato client inizia ad 
eseguire il sistema **GoInGameClientSystem**, che invia una RPC al server; lato server inizia ad eseguire il 
sistema **GoInGameServerSystem** che riceve la RPC e marchia il client come "in gioco", aggiungendo il 
componente **NetworkStreamInGame** all'entità che rappresenta la connessione.

