using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UISetter : MonoBehaviour
{
    public GameObject MultiplayerUI;
    public GameObject SinglePlayerUI;
    public TextMeshProUGUI Score1;
    public TextMeshProUGUI Score2;
    public TextMeshProUGUI Score;

    void Start()
    {
        if(GameState.isMultiplayer==true){
            MultiplayerUI.SetActive(true);
            SinglePlayerUI.SetActive(false);
        }else{
            MultiplayerUI.SetActive(false);
            SinglePlayerUI.SetActive(true);

        }
    }

    void Update(){
        if(GameState.isMultiplayer==true){
            if(PhotonNetwork.CurrentRoom.PlayerCount==1){
                Score1.text = GameState.Score1.ToString();
            }
            if(PhotonNetwork.CurrentRoom.PlayerCount==2){
                Score2.text = GameState.Score2.ToString();
            }
        }else{
            Score.text = GameState.Score.ToString();
        }
        
    }

}
