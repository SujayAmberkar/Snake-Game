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

    void Start() {
        if(GameState.isMultiplayer){
            MultiplayerSpawning();
        }else{
            SinglePlayerSpawning();
        }
        
    }

    void MultiplayerSpawning(){
            Vector2 randomPosition = new Vector2(Random.Range(minX,maxX),Random.Range(miny,maxY));
            PhotonNetwork.Instantiate(playerPrefab.name,randomPosition,Quaternion.identity);
    }

    void SinglePlayerSpawning(){
        Vector2 randomPosition = new Vector2(Random.Range(minX,maxX),Random.Range(miny,maxY));
        Instantiate(playerPrefab,randomPosition,Quaternion.identity);
    }

    
}
