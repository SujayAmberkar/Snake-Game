using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFood : MonoBehaviour
{
    private float _foodDirection;

    void Update()
    { 
        alternateDirection();
    }

    void FixedUpdate(){
        VerticalMovement();
    }

    void VerticalMovement(){
        this.transform.position = new Vector3(
            0,
            (transform.position.y + _foodDirection),
            0
        );
    }

    void alternateDirection(){
        if(transform.position.y<-4){
            _foodDirection = Vector2.up.y;
        }
        if(transform.position.y>4){
            _foodDirection = Vector2.down.y;
        }
    }
}
