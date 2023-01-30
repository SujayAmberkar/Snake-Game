using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    
    void Start() {
        Debug.Log("Player Death");    
    }
    void Update(){

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Body" || other.tag=="Wall"){
            Debug.Log("Player Death");
            SceneManager.LoadScene("End");
        }    
    }
}
