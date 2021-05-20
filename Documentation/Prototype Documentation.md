
# Prototype Documentation (ENG)

The prototype consists of a small multiplayer videogame in which each player controls their capsule character,
moving it inside the map and interacting with many scene objects. It was made entirely with the packages
provided by DOTS.
<br/>
<p align="center">
	<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Documentazione%20Prototipo.md">Italiano</a>
	·
	<a href="https://github.com/mikyll/UnityDOTS-Thesis">Home page</a>
</p>

<!-- TABLE OF CONTENTS -->
<details open="open">
	<summary><h2 style="display: inline-block">Index</h2></summary>
	<ol>
		<li><a href="#prototype-goal">Prototype Goal</a></li>
		<li><a href="#main-features">Main Features</a></li>
		<li><a href="#standalone-build">Standalone Build</a></li>
		<li><a href="#execution-flow">Execution Flow</a></li>
		<li><a href="#code">Code</a>
			<ul>
				<li><a href="#connections">Connections</a></li>
				<li><a href="#input">Input</a></li>
				<li><a href="#movement">Movement</a></li>
				<li><a href="#third-person-camera-view">Third Person Camera View</a></li>
				<li><a href="#color-change-portals">Color-Change Portals</a></li>
				<li><a href="#teleports">Teleports</a></li>
				<li><a href="#entity-spawn">Entity Spawn</a></li>
				<li><a href="#entity-pick-up">Entity Pick Up</a></li>
			</ul>
		</li>
		<li><a href="#references">References</a>
			<ul><a href="#documentation">Documentation</a></ul>
			<ul><a href="#github-repositories">GitHub Repositories</a></ul>
		</li>
	</ol>
</details>

## Prototype Goal

The goal of the prototype is to create a basic gameplay, implementing characters movement and smallinteractions with the game environment, using the packages provided by Unity DOTS architecture.
In particular, the following packages were used:
* Entities, to realize the model based on Entities, Components and Systems (ECS).
* NetCode, to implement the networking side, that is the connections of the players (clients) to the game server and the communication between them.
* Physics, to realize the mechanics related to physics (static/dynamic entities, collision system, etc.).


## Main Features

<table>
	<tr>
		<td><b>Feature</b></td>
		<td><b>File</b></td>
		<td width="40%"><b>Demo</b></td>
	</tr>
	<tr>
		<td>Input stacking and capsule player movement</td>
		<td><a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/PlayerMovementSpeed.cs">PlayerMovementSpeed</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PlayerInputSystem.cs">PlayerInputSystem.cs</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PlayerMovementSystem.cs">PlayerMovementSystem.cs</a></td>
		<td width="40%"><img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/GIF_Movement.gif" alt="MovimentoGIF"/></td>
	</tr>
	<tr>
		<td>Third person camera follow</td>
		<td><a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/PlayerCameraFollowComponent.cs">PlayerCameraFollowComponent.cs</a><br/>
			<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/CameraFollowSystem.cs">CameraFollowSystem.cs</a></td>
		<td width="40%"><img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/GIF_CameraFollow.gif" alt="CameraFollowGIF"/></td>
	</tr>
	<tr>
		<td>Color change portals</td>
		<td><a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/PersistentChangeMaterialOnTriggerComponent.cs">PersistentChangeMaterialOnTriggerComponent.cs</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PersistentChangeMaterialOnTriggerSystem.cs">PersistentChangeMaterialOnTriggerSystem.cs</a><br/><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/TemporaryChangeMaterialOnTriggerComponent.cs">TemporaryChangeMaterialOnTriggerComponent.cs</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/TemporaryChangeMaterialOnTriggerSystem.cs">TemporaryChangeMaterialOnTriggerSystem.cs</a></td>
		<td width="40%"><img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/GIF_ChangeMaterialPortals.gif" alt="PortaliColoreGIF"/></td>
	</tr>
	<tr>
		<td>Teleports</td>
		<td><a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/TeleportComponent.cs">TeleportComponent.cs</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/TeleportSystem.cs">TeleportSystem.cs</a></td>
		<td width="40%"><img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/GIF_Teleport.gif" alt="TeletrasportoGIF"/></td>
	</tr>
	<tr>
		<td>Entities spawn at random points in a volume</td>
		<td><a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/SpawnRandomObjectsAuthoring.cs">SpawnRandomObjectsAuthoring.cs</a></td>
		<td width="40%"><span float="left"><img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/GIF_SpawnEntities.gif" alt="SpawnEntitiesGIF" width="60%"/>
		<img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/InspectorSpawnRandomAuthoring.png" alt="SpawnEntitiesGIF" width="35%"/><span></td>
	</tr>
	<tr>
		<td>Collectibles pick up</td>
		<td><a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/PlayerScoreComponent.cs">PlayerScoreComponent</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/PickUpSystem.cs">CollectibleTagComponent.cs</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Components/DeleteTagComponent.cs">DeleteTagComponent.cs</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/PickUpSystem.cs">PickUpSystem.cs</a><br/>
		<a href="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/DOTS%20Prototype/Assets/Scripts/Systems/DeleteCollectibleSystem.cs">DeleteCollectibleSystem.cs</a></td>
		<td width="40%"><img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/GIF_PickupCollectibles.gif" alt="CollectiblesGIF"/></td>
	</tr>
</table>


## Standalone Build

To make the <a href="https://docs.unity3d.com/Packages/com.unity.entities@0.17/manual/install_setup.html#standalone-builds">standalone build</a> of an application created using DOTS, it is necessary to use the Platforms packages (com.unity.platforms.\*). In particular, in the case of a <a href="https://docs.unity3d.com/Packages/com.unity.netcode@0.6/manual/client-server-worlds.html#standalone-builds">multiplayer application</a>, NetCode uses the Server Build property in Build Settings and the scripting define symbols in **Project Settings** > **Player** to decide what type of application to build (client only, server only or chosen at runtime).

### Example on Windows
1. Check that com.unity.platforms.windows is installed in the PackageManager.
2. Create a Build Configuration: **Project Window** > **Create** > **Build** > **Windows Classic Build Configuration**.
3. Select the configuration and run the build.
<p float="left">
<img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/WindowsBuild%20(1).png" alt="WindowsBuild (1)" width="50%"/>
<img src="https://github.com/mikyll/UnityDOTS-Thesis/blob/main/Documentation/Images/WindowsBuild%20(2).png" alt="WindowsBuild (2)" width="45%"/>
</p>

## Execution Flow

The prototype execution flow is the following:
1. When the application starts, the Game system (contained in Game.cs file) runs. This system implements the connection of the clients to the server, differentiating the execution of the server, which listens for connections, from the execution of the clients, which connect to the server.
2. Clients execute the code of GoInGameClientSystem, that sends a request to the server to enter the game
and then starts sending commands and receiving snapshots (i.e. game state updates).
3. The server executes the code of GoInGameServerSystem, that receives requests to enter the game and for each player enables communication via commands and snapshots, and generates a capsule character.
4. The application, through the system PlayerInputSystems, continuously checks if the player enters keyboard inputs, and if so store them in a buffer and sends them to the server.
5. The PlayerMovementSystem applies the inputs to the various capsules, using the client-side prediction to make the execution more fluid and to make the network latency perception as little as possibile.
6. In the meantime, the others systems that implement the various features are also getting updated.

## Code

NB: the code snippets shown in the following section have been cut out to highlight the key parts explained in the text.

### Connections
<details>
#### `EnableGame` Component
	
#### `Game` System
	
#### `GoInGameRequest` Component

#### `GoInGameClientSystem` System

#### `GoInGameServerSystem` System
</details>

### Input
<details>
#### `PlayerInput` Command
	
#### `PlayerInputSystem` System
</details>

### Movement
<details>
#### `PlayerMovementSpeed` Component	

#### `PlayerMovementSystem` System
</details>

### Third Person Camera View
<details>	
#### `CameraFollowSystem` System
</details>

### Color-Change Portals
<details>	
#### `TemporaryChangeMaterialOnTriggerSystem` System
	
#### `PersistentChangeMaterialOnTriggerSystem` System
</details>

### Teleports	
<details>	
#### `TeleportComponent` Component
	
#### `TeleportSystem` System
</details>

### Entity spawn
<details>	
#### `SpawnRandomObjectsAuthoring` Component
	
#### `SpawnRandomObjectsSystemBase` System
</details>

### Entity Pick Up
<details>	
#### `PlayerScoreComponent` Component
	
#### `CollectibleTagComponent` Component	
	
#### `DeleteTagComponent` Component
	
#### `PickUpSystem` System
	
#### `DeleteCollectibleSystem` System
</details>


## References
	
### Documentation
* <a href="https://docs.unity3d.com/Manual/index.html">Unity Manual</a>
* <a href="https://docs.unity3d.com/Packages/com.unity.entities@0.17">Unity Entities</a>
* <a href="https://docs.unity3d.com/Packages/com.unity.physics@0.6">Unity Physics</a>
* <a href="https://docs.unity3d.com/Packages/com.unity.netcode@0.6">Unity NetCode</a>
* <a href="https://youtube.com/playlist?list=PLX2vGYjWbI0S1wHRTyDiPtKLEPTWFi4cd">Unity Copenhagen 2019 - DOTS (YouTube Playlist)</a>
<!--<iframe width="560" height="315" src="https://www.youtube.com/embed/BNMrevfB6Q0" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>-->
	
### GitHub Repositories
<!--* <a href="https://github.com/Unity-Technologies/DOTSSample">DOTS Sample</a> - uno sparatutto multigiocatore completo realizzato utilizzando DOTS.
* <a href="https://github.com/Unity-Technologies/EntityComponentSystemSamples">EntityComponentSystemSamples</a> - contiene delle sub-repository, fra cui anche UnityPhysicsSamples, con esempi, demo e use cases molto utili.
* <a href="https://github.com/Unity-Technologies/FPSSample">FPS Sample</a> - obsoleto ma è un progetto interessante.
* <a href="https://github.com/UnityTechnologies/AngryBots_ECS">AngryBots ECS</a> - semplice gioco in terza persona che mostra in modo semplice alcuni vantaggi dell'utilizzo di DOTS.-->
	
	
TO-DO Translate Italian doc [...]
