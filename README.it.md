<!-- PROJECT SHIELDS -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![GitHub followers][github-shield]][github-url]


<!-- PROJECT LOGO -->
<br />
<p align="center">
  <!--<a href="https://github.com/mikyll/UnityDOTS-Thesis">
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
    <a href="./Documentation/Documentazione%20Prototipo.md"><strong>Esplora la documentazione »</strong></a>
    <br />
    <br />
	<a href="./README.md">English</a>
	·
	<a href="#demo">Guarda la Demo</a>
	·
	<a href="./Thesis%20Docs/Tesi%20di%20Laurea%20di%20Michele%20Righi%20-%20Progetto%20di%20Applicazioni%20e%20Giochi%20Multiplayer%20su%20Architettura%20Unity%20DOTS.pdf">Tesi</a>
	·
	<a href="./Presentation/PresentazioneDOTS%20(pdf_compatto).pdf">Presentazione</a>
	·
	<a href="https://github.com/mikyll/UnityDOTS-Thesis/issues">Segnala un Bug | Richiedi una Funzionalità</a>
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

<span id="demo">Le immagini seguenti mostrano un esempio di esecuzione del prototipo, tramite un server headless e due client 
connessi: il primo è in esecuzione nell'editor Unity, il secondo è un'applicazione standalone in esecuzione
su una macchina differente. Usando il package NetCode, quando si entra in PlayMode nell'editor Unity, vengono
messi in esecuzione il server, un client ed un numero arbitrario di *thin clients* (in questo caso non
impostati).</span>
<br/>
<table style="border: none">
  <tr>
    <td width="49.9%"><img src="./Documentation/Images/GIF_Editor_Prototype.gif" alt="EditorGIF"/></td>
    <td width="49.9%"><img src="./Documentation/Images/GIF_AppStandalone_Prototype.gif" alt="StandaloneGIF"/></td>
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
   git clone https://github.com/mikyll/UnityDOTS-Thesis
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
[Documentazione](./Documentation/Documentazione%20Prototipo.md).



<!-- ROADMAP -->
## Roadmap

Vedere la sezione [open issues](https://github.com/mikyll/UnityDOTS-Thesis/issues) per avere la lista completa delle 
possibili funzionalità future (e problemi attualmente conosciuti).

### Problemi Non Risolti
* La visuale in terza persona a volte inizia sfarfallare.
* Le simulazioni fisiche con gli oggetti dinamici non sono sincronizzate fra i client.
* Le build standalone a volte crashano.

### Sviluppi Futuri
* Gestione della disconnessione dei client.
* Un menu principale ed una lobby prepartita-
* Una scoreboard dei giocatori.
* Sistema per l'inventario.


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

Distribuito sotto Licenza MIT. Vedi [`LICENSE`](./LICENSE) per maggiori informazioni.



<!-- CONTACT -->
## Contatti

Michele Righi - righi.michele98@gmail.com

Project Link: [github.com/mikyll/UnityDOTS-Thesis](https://github.com/mikyll/UnityDOTS-Thesis)



<!-- ACKNOWLEDGEMENTS -->
## Ringraziamenti

* Il mio correlatore [Andrea Garbugli](https://www.unibo.it/sitoweb/andrea.garbugli) per avermi proposto un argomento così interessante e per avermi fornito aiuto e supporto nella stesura del documento di tesi. 
* [Othneil Drew](https://github.com/othneildrew) per il magnifico [template del README](https://github.com/othneildrew/Best-README-Template).



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/mikyll/UnityDOTS-Thesis
[contributors-url]: https://github.com/mikyll/UnityDOTS-Thesis/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/mikyll/UnityDOTS-Thesis
[forks-url]: https://github.com/mikyll/UnityDOTS-Thesis/network/members
[stars-shield]: https://img.shields.io/github/stars/mikyll/UnityDOTS-Thesis
[stars-url]: https://github.com/mikyll/UnityDOTS-Thesis/stargazers
[issues-shield]: https://img.shields.io/github/issues/mikyll/UnityDOTS-Thesis
[issues-url]: https://github.com/mikyll/UnityDOTS-Thesis/issues
[license-shield]: https://img.shields.io/github/license/mikyll/UnityDOTS-Thesis
[license-url]: https://github.com/mikyll/UnityDOTS-Thesis/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?logo=linkedin&colorB=0077B5
[linkedin-url]: https://www.linkedin.com/in/michele-righi/?locale=it_IT
[github-shield]: https://img.shields.io/github/followers/mikyll.svg?style=social&label=Follow
[github-url]: https://github.com/mikyll
