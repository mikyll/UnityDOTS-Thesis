using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.NetCode;
using Unity.Collections;
using Unity.Physics;

/*
 * Dato che questo e' un gioco multiplayer, non basta semplicemente campionare l'input e usarlo direttamente,
 * ma bisogna immagazzinarlo da qualche parte (una struct ICommandData) per inviarlo al Server (tramite un system),
 * cosi' che lui possa poi usarli.
 */

// questo e' il modo di farlo senza sporcarsi le mani, il "piu' semplice", altrimenti potremmo implementare manualmente
// i metodi Serialize/Deserialize e tutto il resto (stessa cosa vale per le RPC)
public struct PlayerInput : ICommandData
{
    public uint Tick { get; set; }
    public int horizontal;
    public int vertical;

    public bool jumpEnabled;
    public bool firstJump;
    public bool secondJump;

    public bool toggleScoreBoard;
}

// questo system si occupa di inviare i dati (PlayerInput) dal client al server
[UpdateInGroup(typeof(ClientSimulationSystemGroup))]
[AlwaysSynchronizeSystem]
public class PlayerInputSystem : SystemBase
{

    ClientSimulationSystemGroup m_ClientSimulationSystemGroup;
    protected override void OnCreate()
    {
        RequireSingletonForUpdate<NetworkIdComponent>();
        RequireSingletonForUpdate<EnableGame>();
        m_ClientSimulationSystemGroup = World.GetExistingSystem<ClientSimulationSystemGroup>();
    }

    protected override void OnUpdate()
    {
		// CommandTargetComponent indica l'entità che sarà effetta dall'azione (il personaggio del giocatore)
        var localInput = GetSingleton<CommandTargetComponent>().targetEntity; // ottiene l'entità corrispondente al Singleton CommandTargetComponent (E' un Singleton diverso per ciascun client)
        // se a tale singleton non corrisponde alcuna entità, significa che dobbiamo trovarla, perché di sicuro è stata spawnata da Game.cs quando il giocatore è entrato in gioco.
		if (localInput == Entity.Null)
        {
			// ottiene l'Id di rete del giocatore
            var localPlayerId = GetSingleton<NetworkIdComponent>().Value;
            var commandBuffer = new EntityCommandBuffer(Allocator.Temp);
            var commandTargetEntity = GetSingletonEntity<CommandTargetComponent>();
            // trova tutte le entità personaggio (in questo caso CapsulePlayer)
			Entities.WithAll<PlayerMovementSpeed>().WithNone<PlayerInput>().ForEach((Entity ent, ref GhostOwnerComponent ghostOwner) =>
            {
				// filtra solo quella in cui l'Id del proprietario del ghost corrisponde con l'Id di rete del nostro giocatore
                if (ghostOwner.NetworkId == localPlayerId)
                {
					// quindi si aggiunge il buffer per i comandi di input
                    commandBuffer.AddBuffer<PlayerInput>(ent);
					// e si imposta il riferimento del singleton all'entità del personaggio del giocatore
                    commandBuffer.SetComponent(commandTargetEntity, new CommandTargetComponent { targetEntity = ent });
                }
            }).Run();
            commandBuffer.Playback(EntityManager);
            return;
        }
        
		// se il codice arriva qui significa che CommandTargetComponent possiede il riferimento all'entità del personaggio del giocatore, a cui applicare i comandi
		var input = default(PlayerInput);
        // aggiorniamo il tick e successivamente i movimenti
		input.Tick = m_ClientSimulationSystemGroup.ServerTick;
        // movimento
        if (Input.GetKey("a"))
            input.horizontal -= 1;
        if (Input.GetKey("d"))
            input.horizontal += 1;
        if (Input.GetKey("s"))
            input.vertical -= 1;
        if (Input.GetKey("w"))
            input.vertical += 1;
        // salto
        if (Input.GetKey("space"))
            input.firstJump = true;
        // scoreboard
        if (Input.GetKey("tab"))
            input.toggleScoreBoard = true;
        if (Input.GetKeyUp("tab"))
            input.toggleScoreBoard = false;
        var inputBuffer = EntityManager.GetBuffer<PlayerInput>(localInput);
        inputBuffer.AddCommandData(input); // aggiungiamo infine il nuovo comando al buffer, che verrà inviato
    }
}
