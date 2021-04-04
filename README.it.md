
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
<!--
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
-->



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <!--<a href="https://github.com/mikyll/TesiUnityDOTS">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>-->

  <h1 align="center">Progetto di Applicazioni e Giochi Multiplayer<br/>su Architettura Unity DOTS</h1>

  <p align="center">
	Questo progetto è stato realizzato come parte integrante della mia tesi di laurea triennale, riguardante appunto
	la nuova architettura Unity DOTS. L'obbiettivo dell'elaborato, oltre all'analisi del nuovo layout orientato ai
	dati fornito dal modello basato su ECS, era quello di creare un <i>prototipo di gioco multiplayer funzionante.</i>
	<!--A tal proposito sono stati utilizzati i vari package forniti dallo stack DOTS, con particolare attenzione
	a Entities (che realizza il modello a Entità, Componenti e Sistemi) e NetCode (che implementa il 
	networking).
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
    <a href="https://github.com/github_username/repo_name">View Demo</a>
    ·
    <a href="https://github.com/github_username/repo_name/issues">Report Bug</a>
    ·
    <a href="https://github.com/github_username/repo_name/issues">Request Feature</a>
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
    <!--<li><a href="#licenza">Licenza</a></li>-->
    <li><a href="#contatti">Contatti</a></li>
    <li><a href="#ringraziamenti">Ringraziamenti</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## Il Progetto

[![Product Name Screen Shot][product-screenshot]](https://example.com)

Here's a blank template to get started:
**To avoid retyping too much info. Do a search and replace with your text editor for the following:**
`github_username`, `repo_name`, `twitter_handle`, `email`, `project_title`, `project_description`

### Sviluppato Con

* [Unity](https://unity.com/)
* [DOTS](https://unity.com/dots)
* [Microsoft Visual Studio](https://visualstudio.microsoft.com/)



<!-- GETTING STARTED -->
## Per iniziare

Per chi non ha troppa familiarità con GitHub ottenere una copia locale funzionante seguire i passi riportati in seguito.

### Prerequisiti

* Git
* Unity Hub
* Unity 2020.2.1 o più recente

### Installazione

1. Installare Git presso [Download Git](https://git-scm.com/download)
2. Clonare la repository
   ```sh
   git clone https://github.com/mikyll/TesiUnityDOTS
   ```
3. Scaricare Unity Hub presso [Download Unity](https://unity3d.com/get-unity/download)
4. Installare una versione Unity appropriata (2020.2.1 o superiore) presso [Download Archive](https://unity3d.com/get-unity/download/archive) oppure direttamente dall'apposita sezione su Unity Hub.
5. Aggiungere il progetto su Unity Hub: Projects > Add > Select Directory



<!-- USAGE EXAMPLES -->
## Utilizzo

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

Per ulteriori esempi fare riferimento alla [Documentazione](https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Documentazione%20Prototipo.md)



<!-- ROADMAP -->
## Roadmap

Vedere la sezione [open issues](https://github.com/mikyll/TesiUnityDOTS/issues) per avere una lista di possibili funzionalità future e (problemi attualmente conosciuti).

### Problemi Non Risolti
* The third person camera sometime starts flickering.
* The collision system doesn't work properly between static entities and ghost entities if those are moving updating Translation component. For this reason we updated the PhysicsVelocity component of the PlayerCapsule, but the movement is obviously different (it needs to accelerate from zero).
* Sometimes the application throws an error.
* Infrequent random crashes of the standalone builds.

### Sviluppi Futuri
* Players scoreboard (esiste già un sistema di punteggio)
* Pre-match lobby
* assign different colors on connect
* switchable first-person camera using Unity RayCast


<!-- CONTRIBUTING -->
## Contributire

I contributi sono ciò che rende la community open source il posto meraviglioso che è, per imparare, trarre ispirazione e creare contenuti.
Qualsiasi contributo aggiunto, che sia un parere costruttivo, il report di un bug scoperto, una soluzione ad un problema o anche solo un'idea su come risolverlo, è **largamente apprezzato**!

1. Eseguire una Fork del Progetto.
2. Creare un Branch per la propria Feature (`git checkout -b feature/AmazingFeature`)
3. Eseguire il Commit dei propri Cambiamenti (`git commit -m 'Add some AmazingFeature'`)
4. Eseguire il Push al proprio Branch (`git push origin feature/AmazingFeature`)
5. Aprire una Richiesta di Pull



<!-- LICENSE -->
<!--## License

Distributed under the MIT License. See `LICENSE` for more information.-->



<!-- CONTACT -->
## Contatti

Michele Righi - <!-- [@twitter_handle](https://twitter.com/twitter_handle) - -->righi.mikyll@gmail.com

Project Link: [https://github.com/mikyll/TesiUnityDOTS](https://github.com/mikyll/TesiUnityDOTS)



<!-- ACKNOWLEDGEMENTS -->
## Ringraziamenti

<!--* il mio correlatore [Andrea Garbugli]() per la proposta dell'argomento di tesi ed il supporto e aiuto nella stesura della tesi-->
* []()
* [Othneil Drew](https://github.com/othneildrew/Best-README-Template) per il magnifico template del README.





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/github_username/repo.svg?style=for-the-badge
[contributors-url]: https://github.com/github_username/repo/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/github_username/repo.svg?style=for-the-badge
[forks-url]: https://github.com/github_username/repo/network/members
[stars-shield]: https://img.shields.io/github/stars/github_username/repo.svg?style=for-the-badge
[stars-url]: https://github.com/github_username/repo/stargazers
[issues-shield]: https://img.shields.io/github/issues/github_username/repo.svg?style=for-the-badge
[issues-url]: https://github.com/github_username/repo/issues
[license-shield]: https://img.shields.io/github/license/github_username/repo.svg?style=for-the-badge
[license-url]: https://github.com/github_username/repo/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/github_username
