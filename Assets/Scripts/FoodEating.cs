using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FoodEating : MonoBehaviour
{
    public SnakeController snake;
    public FoodSpawner spawnFood;
    private PlayerScore playerScore;
    

    void Start(){
        Debug.Log("Start");
        playerScore = GetComponent<PlayerScore>();
    }

    // on eating the food
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Food"){
            Debug.Log("Collision");
            // spawnFood.SpawnFood();
            ScoreIncrement();
            ScoreIncrementMultiPlayer();
            snake.AddSegment();
        }
    }

    void ScoreIncrement(){
        if(!GameState.isMultiplayer)
            GameState.Score+=1;
    }

    void  ScoreIncrementMultiPlayer(){
        if(GameState.isMultiplayer){
            // if(PhotonNetwork.LocalPlayer.ActorNumber==1){
            //     GameState.Score1++;
            // }
            // if(PhotonNetwork.LocalPlayer.ActorNumber==2){
            //     GameState.Score2++;
            // }
            playerScore.score++;
            GetComponent<PhotonView>().RPC("UpdateScore", RpcTarget.AllBuffered, playerScore.score);
            }
        }
    }

