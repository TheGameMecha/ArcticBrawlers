using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Prototype.NetworkLobby
{


    public class PlayerName_Hook : NetworkLobbyHook
    {

        public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
        {
            LobbyPlayer p = lobbyPlayer.GetComponent<LobbyPlayer>();
           
            
        }

    }
}
