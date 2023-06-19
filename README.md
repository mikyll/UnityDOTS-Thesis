<div align="center">

<!-- PROJECT SHIELDS -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![GitHub followers][github-shield]][github-url]

<!-- PROJECT LOGO -->
<!-- <a href="https://github.com/mikyll/UnityDOTS-Thesis">
<img src="images/logo.png" alt="Logo" width="80" height="80">
</a> -->

<h1 align="center">Multiplayer Applications and Games Project<br/>on Unity DOTS Architecture</h1>
This project was carried out as an integral part of my bachelor's degree thesis in Computer Engineering, concerning the new Unity DOTS architecture. The goal of the paper, in addition to analyzing the new data-oriented layout provided by the ECS-based model, was to create a <i>working multiplayer game prototype made entirely using DOTS.</i>
<br />
<a href="./Documentation/Prototype%20Documentation.md"><strong>Explore the docs »</strong></a>
<br />
<br />
<a href="./README.it.md">Italiano <kbd><img width="20px" src="https://flagicons.lipis.dev/flags/4x3/it.svg"></kbd></a>
·
<a href="#demo">View Demo</a>
·
<a href="./Thesis%20Docs/Tesi%20di%20Laurea%20di%20Michele%20Righi%20-%20Progetto%20di%20Applicazioni%20e%20Giochi%20Multiplayer%20su%20Architettura%20Unity%20DOTS.pdf">Thesis</a>
·
<a href="./Presentation/PresentationDOTS%20(pdf).pdf">Presentation</a>
·
<a href="https://github.com/mikyll/UnityDOTS-Thesis/issues">Report Bug | Request Feature</a>
</div>


<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
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
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[Data-Oriented Technology Stack (DOTS)](https://unity.com/dots) is a set of 
[libraries](https://unity.com/dots/packages) created by Unity over the last few years, which is still under 
development.<br/>
DOTS proposes to replace the old architecture of the game engine, that was based on a component model
(GameObject + MonoBehaviour), with a new one based on ECS (Entities, Components, Systems). The goal is to
obtain an architecture that is not limited by the objective-oriented programming, which is known to have
several pifalls and problems, mainly related to polymorphism, inheritance chains and reference types. In this regard,
through a data-oriented layout, DOTS allows to obtain *performance by default*, as the code becomes
organized by the separation between data (inside the components) and the behaviour (confined inside systems).
Runtime "things" are no longer heavy objects, with data scattered in memory, but simple numeric indexes
(representing entities), which we can compare to the keys of a database. Among the many advantages that come
with this new architecture, stand out the possibility of making the most of modern CPUs, exploiting the 
potential of multiple cores and allowing efficient use of caches, which are not satured by the myriad of
useless or unnecessary data present in objects. Moreover, thanks to the separation logic, the code that
developers write becomes a good low-level approximation of an already correct and efficient solution, which
therefore doesn't need, if not in rare cases, to be optimized.<br/>
The main packages used to make the prototype are:
* [Entities](https://docs.unity3d.com/Packages/com.unity.entities@0.17) - implements the ECS model.
* [Physics](https://docs.unity3d.com/Packages/com.unity.physics@0.6) - implements the physics.
* [NetCode](https://docs.unity3d.com/Packages/com.unity.netcode@0.6) - implements the networking.

<span id="demo">The following images show an example run of the prototype, with an headless server and two connected clients: the first one is running in the Unity editor, the second one is a standalone application running on a different computer. Using the NetCode package, when entering PlayMode in the editor, Unity runs the server, a client and an arbitrary number of thin clients (in this case we didn't set any of those).</span>
<table style="border: none">
  <tr>
    <td width="49.9%"><img src="./Documentation/Images/GIF_Editor_Prototype.gif" alt="EditorGIF"/></td>
    <td width="49.9%"><img src="./Documentation/Images/GIF_AppStandalone_Prototype.gif" alt="StandaloneGIF"/></td>
  </tr>
  <tr>
    <td>PC1: Unity Editor</td>
    <td>PC2: Standalone Build</td>
  </tr>
</table>


### Built With

* [Unity](https://unity.com/)
* [DOTS](https://unity.com/dots)
* [Microsoft Visual Studio](https://visualstudio.microsoft.com/)



<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

* Git
* Unity Hub
* Unity 2020.2.1 or higher

### Installation

1. Install Git at [Download Git](https://git-scm.com/download).
2. Clone the repo.
   ```sh
   git clone https://github.com/mikyll/UnityDOTS-Thesis
   ```
3. Download Unity Hub at [Download Unity](https://unity3d.com/get-unity/download).
4. Install a proper Unity version (2020.2.1 or higher) at [Download Archive](https://unity3d.com/get-unity/download/archive) or from Unity Hub.
5. Add the project directory on Unity Hub: Projects > Add > Select Directory.



<!-- USAGE EXAMPLES -->
## Usage

To test the prototype in multiplayer you can create a build for a standalone client, then enter PlayMode in the editor and connect the standalone application; otherwise you can create one build for the server and one for the client and connect several clients to the server.

For more examples, please refer to the [Documentation](./Documentation/Prototype%20Documentation.md).



<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/mikyll/UnityDOTS-Thesis/issues) for the full list of proposed features (and known issues).

### Open Issues
* The third person camera sometime starts flickering.
* Physics simulations with dynamic entities are not synchronized between different clients.
* Standalone builds sometime crash.

### Future developments
* Clients disconnection handle.
* Main menu where and pre-match lobby.
* Player scoreboard.
* Inventory mechanic.


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project.
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`).
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the Branch (`git push origin feature/AmazingFeature`).
5. Open a Pull Request.



<!-- LICENSE -->
## License

Distributed under the MIT License. See [`LICENSE`](./LICENSE) for more information.



<!-- CONTACT -->
## Contact

Michele Righi - righi.michele98@gmail.com

Project Link: [github.com/mikyll/UnityDOTS-Thesis](https://github.com/mikyll/UnityDOTS-Thesis)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* My co-supervisor [Andrea Garbugli](https://www.unibo.it/sitoweb/andrea.garbugli) for having suggested me this extremely interesting thesis topic and for the help and support in drafting the paper.
* [Othneil Drew](https://github.com/othneildrew) for the amazing [README template](https://github.com/othneildrew/Best-README-Template).



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
[linkedin-url]: https://www.linkedin.com/in/michele-righi/?locale=en_US
[github-shield]: https://img.shields.io/github/followers/mikyll.svg?style=social&label=Follow
[github-url]: https://github.com/mikyll
