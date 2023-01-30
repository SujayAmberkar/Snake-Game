using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreBoard : MonoBehaviour
{

    public TextMeshProUGUI score;

    void Start(){
        score.text = GameState.Score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
