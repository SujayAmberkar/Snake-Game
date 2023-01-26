using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    // public ConnectToServer isMulti;
    public GameObject playerPrefab;
    public float minX;
    public float maxX;
    public float miny;
    public float maxY;



    void MultiplayerSpawning(){
        Vector2 randomPosition = new Vector2(Random.Range(minX,maxX),Random.Range(miny,maxY));
        PhotonNetwork.Instantiate(playerPrefab.name,randomPosition,Quaternion.identity);
    }

    
}
