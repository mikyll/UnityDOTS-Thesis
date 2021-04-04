
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

  <h3 align="center">Multiplayer Applications and Games Project on Unity DOTS Architecture</h3>

  <p align="center">
    This project was carried out as an integral part of my bachelor's degree thesis in Computer Engineering, concerning the new Unity DOTS architecture. The goal of the paper, in addition to analyzing the new data-oriented layout provided by the ECS-based model, was to create a <i>working multiplayer game prototype made entirely using DOTS.</i>
    <br />
    <a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Prototype%20Documentation.md"><strong>Explore the docs »</strong></a>
    <br />
    <br />
	<a href="https://github.com/mikyll/TesiUnityDOTS/blob/main/README.it.md">Italiano</a>
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
    <!--<li><a href="#license">License</a></li>-->
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

The following images show an example run of the prototype, with an headless server and two connected clients: the first one is running in the Unity editor, the second one is a standalone application running on a different computer. Using the NetCode package, when entering PlayMode in the editor, Unity runs the server, a client and an arbitrary number of thin clients (in this case we didn't set any of those).
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

<!--Here's a blank template to get started:
**To avoid retyping too much info. Do a search and replace with your text editor for the following:**
`github_username`, `repo_name`, `twitter_handle`, `email`, `project_title`, `project_description`-->


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
   git clone https://github.com/mikyll/TesiUnityDOTS
   ```
3. Download Unity Hub at [Download Unity](https://unity3d.com/get-unity/download).
4. Install a proper Unity version (2020.2.1 or higher) at [Download Archive](https://unity3d.com/get-unity/download/archive) or from Unity Hub.
5. Add the project directory on Unity Hub: Projects > Add > Select Directory.



<!-- USAGE EXAMPLES -->
## Usage

To test the prototype in multiplayer you can create a build for a standalone client, then enter PlayMode in the editor and connect the standalone application; otherwise you can create one build for the server and one for the client and connect several clients to the server.

For more examples, please refer to the [Documentation](https://github.com/mikyll/TesiUnityDOTS/blob/main/Documentation/Prototype%20Documentation.md)



<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/mikyll/TesiUnityDOTS/issues) for a list of proposed features (and known issues).

### Open Issues
* The third person camera sometime starts flickering.
* The collision system doesn't work properly between static entities and ghost entities if those are moving updating Translation component. For this reason we updated the PhysicsVelocity component of the PlayerCapsule, but the movement is obviously delayed, because it needs to accelerate from zero.
* Collision and Interactions between ghosts and dynamic object doesn't always work as expected (sometimes the ghost of the CapsulePlayer passes through the dynamic object, even though they should collide).
* Sometimes the application throws an error at runtime or when exiting PlayMode.
* Infrequent random crashes of the standalone builds, probably caused by the aforementioned error.

### Future developments
* Main menu where players can set their nickname and start the matchmaking with the click of a button.
* A pre-match lobby where players can see each other and say when they're ready to start the match.
* The assignment of different colors to the capsules of the various players who connect.
* A scoreboard showing the current score of all connected players (there is already a score system and the system that handles the scoreboard showing with *TAB* command).
* A working mechanic for the jump (which turns usable only when the character hits the ground).
* Capsule steering system, which turns the heading of the capsule to the mouse pointer, using Unity Physics RayCasts.
* The ability to change the camera view from third to first person.


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
<!--## License

Distributed under the MIT License. See `LICENSE` for more information.-->



<!-- CONTACT -->
## Contact

Michele Righi - <!-- [@twitter_handle](https://twitter.com/twitter_handle) - -->righi.mikyll@gmail.com

Project Link: [https://github.com/mikyll/TesiUnityDOTS](https://github.com/mikyll/TesiUnityDOTS)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* []()
* []()
* []()





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
[linkedin-url]: https://www.linkedin.com/in/michele-righi-095283195/?locale=en_US
