using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    

    // Once connected to the server Join the lobby
    public override void OnConnectedToMaster(){ 
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected!!");
        GameState.isMultiplayer = true;
    }

    // Once the player joined the lobby load the create and join lobby scene
    public override void OnJoinedLobby()
    { 
        SceneManager.LoadScene("Lobby");
        Debug.Log("Lobby Joined");
    }

    // connect to photon loadbalancing server
    public void StartMultiplayer(){
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting...");
    }
}
