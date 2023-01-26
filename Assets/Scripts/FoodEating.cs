using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodEating : MonoBehaviour
{
    private int _Score = 0;
    private int _Snakelength=0;
    public TextMeshProUGUI ScoreUI;
    public Food food;
    public SnakeController snake;

    void Start(){
        Debug.Log("Start");
    }

    // on eating the food
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Food"){
            Debug.Log("Collision");
            ScoreIncrement();
            LengthIncrement();
            food.PositionRandomizer();
            snake.SpeedIncrease();
            snake.AddSegment();
        }
    }

    void ScoreIncrement(){
        _Score+=1;
        ScoreUI.SetText(_Score.ToString());
    }

    void LengthIncrement(){
        _Snakelength+=1;
    }


    

}
