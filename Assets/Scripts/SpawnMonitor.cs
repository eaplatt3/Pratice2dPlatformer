using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonitor : MonoBehaviour
{

    public int maxPlatforms = 20;
    public GameObject platform;

    //Max & Min Spawning Distance from each Platform 
    public float horizontalMin = 7.5f;
    public float horizontalMax = 14f;
    public float verticalMin = -6f;
    public float verticalMax = 6f;

    private Vector2 originPosition;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position; //1st Postion will be Transform of Spawn Manager
        Spawn();
    }

   void Spawn()
    {
        //Spawns Plaforms Randomly 
        for(int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity); //Quaternion -> No Rotation
            originPosition = randomPosition; //New Origin is last Random Position
        }
    }
}
