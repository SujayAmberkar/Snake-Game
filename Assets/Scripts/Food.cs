using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PositionRandomizer(){
        float xPos = Mathf.Round(Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x+1, mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x-1));
        float yPos = Mathf.Round(Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y+1, mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y-1));
        Vector3 randomPos = new Vector3(xPos, yPos, 0);
        transform.position = randomPos;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Snake"){
            PositionRandomizer();
        }
    }
}
