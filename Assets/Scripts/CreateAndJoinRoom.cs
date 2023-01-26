using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    // Create a new room with the name entered entered in joinInput. Will be attached to create button
    public void CreateRoom(){ 
        PhotonNetwork.CreateRoom(createInput.text);
    }

    // Join an existing room with the name entered in joinInput. Will be attached to join button
    public void JoinRoom(){
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    // Load the main Game scene when the player joins the room
    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("SinglePlayer");
    }
}