

<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
***
***
***
*** To avoid retyping too much info. Do a search and replace for the following:
*** github_username, repo_name, twitter_handle, email, project_title, project_description
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]




<!-- PROJECT LOGO -->
<br />
<p align="center">
  <!--<a href="https://github.com/mikyll/TesiUnityDOTS">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>-->

  <h1 align="center">Progetto di Applicazioni e Giochi Multiplayer<br/>su Architettura Unity DOTS</h1>

  <p align="center">
	Questo progetto è stato realizzato come parte integrante della mia tesi di laurea triennale in Ingegneria
	Informatica, riguardante appunto la nuova architettura Unity DOTS. L'obbiettivo dell'elaborato, oltre 
	all'analisi del nuovo layout orientato ai dati fornito dal modello basato su ECS, era quello di creare 
	un <i>prototipo di gioco multiplayer funzionante realizzato interamente sfruttando DOTS.</i>
	<!--A tal proposito sono stati utilizzati i vari package forniti dallo stack DOTS, con particolare 
	attenzione a Entities (che realizza il modello a Entità, Componenti e Sistemi) e NetCode (che implementa 
	il networking).
	Il motivo che ha spinto Unity alla ristrutturazione dell'architettura del proprio game engine è dovuto
	al fatto che questa era limitata dal modello basato su componenti, troppo legato all'Object-Oriented
	Programming. Infatti, come è ormai risaputo, questo modello ha diversi problemi, dovuti principalmente
	al polimorfismo, alle catene di ereditarietà ed ai tipi riferimento.
	Dunque, con DOTS Unity si propone di superare questi limiti fornendo un'architettura efficiente e
	performante a priori, in modo tale che gli sviluppatori non debbano preoccuparsi delle prestazioni
	del codice che scrivono, se non come ultimo aspetto.-->
    <br />
    <a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Documentazione%20Prototipo.md"><strong>Esplora la documentazione »</strong></a>
    <br />
    <br />
	<a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/README.md">English</a>
	·
    <a href="https://github.com/mikyll/TesiUnityDOTS">View Demo</a>
    ·
    <a href="https://github.com/mikyll/TesiUnityDOTS/issues">Report Bug</a>
    ·
    <a href="https://github.com/mikyll/TesiUnityDOTS/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Indice</h2></summary>
  <ol>
    <li>
      <a href="#il-progetto">Il Progetto</a>
      <ul>
        <li><a href="#sviluppato-con">Sviluppato Con</a></li>
      </ul>
    </li>
    <li>
      <a href="#per-iniziare">Per Iniziare</a>
      <ul>
        <li><a href="#prerequisiti">Prerequisiti</a></li>
        <li><a href="#installazione">Installazione</a></li>
      </ul>
    </li>
    <li><a href="#utilizzo">Utilizzo</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contribuire">Contributire</a></li>
    <li><a href="#licenza">Licenza</a></li>
    <li><a href="#contatti">Contatti</a></li>
    <li><a href="#ringraziamenti">Ringraziamenti</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## Il Progetto

[Data-Oriented Technology Stack (DOTS)](https://unity.com/dots) è un insieme di 
[librerie](https://unity.com/dots/packages) realizzate dagli sviluppatori di Unity nel corso degli ultimi 
anni, tutt'oggi in fase di sviluppo.<br/>
DOTS si propone di sostituire la vecchia architettura, basata su un modello a componenti (GameObject + 
MonoBehaviour), con una nuova basata su ECS (Entità, Componenti e Sistemi). L'obbiettivo è ottenere 
un'architettura non limitata dalla programmazione a oggetti, in quanto come sappiamo presenta diversi 
problemi, legati soprattutto al polimorfismo, alle catene di ereditarietà ed ai tipi riferimento. A tal 
proposito, tramite un layout orientato ai dati, DOTS permette di ottenere *performance by default*, in 
quanto il codice viene organizzato separando i dati (racchiusi nei componenti) dal comportamento (confinato 
nei sistemi). Le "cose" a tempo di esecuzione non sono più dei pesanti oggetti, con i dati sparpagliati in 
memoria, ma dei semplici indici numerici (che rappresentano le entità), paragonabili alle chiavi di un 
database. Fra i numerosi vantaggi di questa architettura, spiccano la possibilità di utilizzare al meglio le 
CPU moderne, sfruttando il potenziale dei core multipli e permettendo un uso efficiente delle cache, che non 
vengono saturate dalla miriade di dati inutili o superflui presenti negli oggetti. Inoltre, grazie alla 
separazione delle competenze e della logica, il codice che gli sviluppatori scrivono diventa una buona 
approssimazione di basso livello di una soluzione già corretta ed efficiente, che non ha bisogno quindi, se 
non in rari casi, di essere ottimizzata.<br/>
I principali package utilizzati per realizzare il prototipo sono:
* [Entities](https://docs.unity3d.com/Packages/com.unity.entities@0.17) - implementa il modello basato su ECS.
* [Physics](https://docs.unity3d.com/Packages/com.unity.physics@0.6) - realizza la fisica.
* [NetCode](https://docs.unity3d.com/Packages/com.unity.netcode@0.6) - implementa il networking.

Le immagini seguenti mostrano un esempio di esecuzione del prototipo, tramite un server headless e due client 
connessi: il primo è in esecuzione nell'editor Unity, il secondo è un'applicazione standalone in esecuzione
su una macchina differente. Usando il package NetCode, quando si entra in PlayMode nell'editor Unity, vengono
messi in esecuzione il server, un client ed un numero arbitrario di *thin clients* (in questo caso non
impostati).
<br/>
<table style="border: none">
  <tr>
    <td><img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Presentation/GIF_Editor_Prototype.gif" alt="EditorGIF"/></td>
    <td><img src="https://github.com/mikyll/TesiUnityDOTS/blob/main/Presentation/GIF_AppStandalone_Prototype.gif" alt="StandaloneGIF"/></td>
  </tr>
  <tr>
    <td>PC1: Editor Unity</td>
    <td>PC2: Build Standalone</td>
  </tr>
</table>

### Sviluppato Con

* [Unity](https://unity.com/)
* [DOTS](https://unity.com/dots)
* [Microsoft Visual Studio](https://visualstudio.microsoft.com/)



<!-- GETTING STARTED -->
## Per Iniziare

Per chi non ha troppa familiarità con GitHub, per ottenere una copia locale funzionante del prototipo è
necessario seguire i passi riportati in seguito.

### Prerequisiti

* Git
* Unity Hub
* Unity 2020.2.1 o più recente

### Installazione

1. Installare Git presso [Download Git](https://git-scm.com/download).
2. Clonare la repository.
   ```sh
   git clone https://github.com/mikyll/TesiUnityDOTS
   ```
3. Scaricare Unity Hub presso [Download Unity](https://unity3d.com/get-unity/download).
4. Installare una versione Unity appropriata (2020.2.1 o superiore) presso 
[Download Archive](https://unity3d.com/get-unity/download/archive) oppure direttamente dall'apposita sezione 
su Unity Hub.
5. Aggiungere il progetto su Unity Hub: Projects > Add > Select Directory.



<!-- USAGE EXAMPLES -->
## Utilizzo

Per provare il prototipo in multiplayer è possibile creare una build per un client standalone, quindi 
entrare in Play Mode nell'editor Unity e connettere un'applicazione standalone; oppure creare una build per 
il server ed una per il client e connettere diversi client al server.

Per ulteriori esempi fare riferimento alla 
[Documentazione](https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Documentazione%20Prototipo.md).



<!-- ROADMAP -->
## Roadmap

Vedere la sezione [open issues](https://github.com/mikyll/TesiUnityDOTS/issues) per avere una lista di 
possibili funzionalità future (e problemi attualmente conosciuti).

### Problemi Non Risolti
* La camera che segue la capsula a volte inizia a sfarfallare.
* Il sistema di collisioni fra entità statiche e ghost, se questi ultimi si muovo aggiornando il componente
Translation. Per questo motivo per realizzare il movimento della capsula abbiamo dovuto utilizzare il
componente PhysicsVelocity, che però presenta il ritardo dovuto all'accelerazione.
* Le collisioni e le interazioni fra ghost ed oggetti dinamici non funzionano sempre come previsto (a volte
il ghost ci passa attraverso, anche se dovrebbero collidere).
* A volte l'applicazione lancia un errore nel corso dell'esecuzione e all'uscita dalla PlayMode.
* A volte le build standalone crashano, probabilmente a causa dell'errore sopra citato.


### Sviluppi Futuri
* Un menu principale in cui inserire il nickname ed avviare un eventuale matchmaking col click di un bottone.
* Una lobby prepartita in cui i giocatori si possono vedere e possono indicare che sono pronti a iniziare
la partita.
* L'assegnamento di colori differenti alle capsule dei vari giocatori che si connettono.
* Una scoreboard che mostra il punteggio attuale di tutti i giocatori connessi (esiste già un sistema di 
punteggio ed il comando per mostrare la scoreboard con *TAB*, manca solo l'oggetto UI o entità(?) scoreboard 
ed un sistema che la aggiorni).
* L'inserimento di una meccanica funzionante per il salto (che torna utilizzabile quando il personaggio
tocca terra.
* L'aggiunta di un sistema di direzione della capsula, che segue il puntatore del mouse, usando i RayCast 
di Unity Physics.
* La possibilità di cambiare la visuale della videocamera da terza a prima persona.

<!-- CONTRIBUTING -->
## Contribuire

I contributi sono ciò che rende la community open source il posto meraviglioso che è, per imparare, trarre 
ispirazione e creare contenuti.
Qualsiasi contributo aggiunto, che sia un parere costruttivo, il report di un bug scoperto, una soluzione 
ad un problema o anche solo un'idea su come risolverlo, è **largamente apprezzato**!

1. Eseguire una Fork del Progetto.
2. Creare un Branch per la propria Feature (`git checkout -b feature/AmazingFeature`)
3. Eseguire il Commit dei propri Cambiamenti (`git commit -m 'Add some AmazingFeature'`)
4. Eseguire il Push al proprio Branch (`git push origin feature/AmazingFeature`)
5. Aprire una Richiesta di Pull



<!-- LICENSE -->
## Licenza

Distribuito sotto Licenza MIT. See `LICENSE` for more information.



<!-- CONTACT -->
## Contatti

Michele Righi - <!-- [@twitter_handle](https://twitter.com/twitter_handle) - -->righi.mikyll@gmail.com

Project Link: [https://github.com/mikyll/TesiUnityDOTS](https://github.com/mikyll/TesiUnityDOTS)



<!-- ACKNOWLEDGEMENTS -->
## Ringraziamenti

<!--* il mio correlatore [Andrea Garbugli]() per la proposta dell'argomento di tesi ed il supporto e aiuto nella stesura del documento. -->
* []()
* [Othneil Drew](https://github.com/othneildrew) per il magnifico [template del README](https://github.com/othneildrew/Best-README-Template).





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/mikyll/TesiUnityDOTS
[contributors-url]: https://github.com/mikyll/TesiUnityDOTS/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/mikyll/TesiUnityDOTS
[forks-url]: https://github.com/mikyll/TesiUnityDOTS/network/members
[stars-shield]: https://img.shields.io/github/stars/mikyll/TesiUnityDOTS
[stars-url]: https://github.com/mikyll/TesiUnityDOTS/stargazers
[issues-shield]: https://img.shields.io/github/issues/mikyll/TesiUnityDOTS
[issues-url]: https://github.com/mikyll/TesiUnityDOTS/issues
[license-shield]: https://img.shields.io/github/license/mikyll/TesiUnityDOTS
[license-url]: https://github.com/mikyll/TesiUnityDOTS/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/michele-righi-095283195/?locale=it_IT
