using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PositionRandomizer(){
        float xPos = Mathf.Round(Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x));
        float yPos = Mathf.Round(Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y, mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y));
        Vector3 randomPos = new Vector3(xPos, yPos, 0);
        transform.position = randomPos;
    }
}
