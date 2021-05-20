
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
				<li><a href="#connection">Connection</a></li>
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
			<ul><a href="#github-repository">GitHub Repository</a></ul>
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

	
TO-DO Translate Italian doc [...]
