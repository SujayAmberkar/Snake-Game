using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject foodType1;
    public GameObject foodType2;
    float xPos;
    float yPos;
    int foodType = 0;

    void Start() {
        // Instantiate(foodType1,new Vector3(0,0,0),Quaternion.identity);
        Instantiate(foodType2,new Vector3(0,0,0),Quaternion.identity);
        // SpawnFood();  
    }

    public void SpawnFood()
    {
        
        if (foodType == 0)
        {
            foodType1.SetActive(true);
            foodType2.SetActive(false);
            foodType=1;
        }
        else
        {
            foodType1.SetActive(false);
            foodType2.SetActive(true);
            foodType=0;
        }
    }
}