using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Prototype.NetworkLobby
{


    public class PlayerColor_Hook : NetworkLobbyHook {

        public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
        {
            LobbyPlayer p = lobbyPlayer.GetComponent<LobbyPlayer>();
            PlayerColor playerC = gamePlayer.GetComponent<PlayerColor>();

            playerC.color = p.playerColor;
        }
    }
}
