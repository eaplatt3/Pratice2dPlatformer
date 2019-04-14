using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{

    public Transform[] coinSpawns;
    public GameObject coin;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        //Spawns Coins
        for(int i =0; i < coinSpawns.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip > 0)
                Instantiate(coin, coinSpawns[i].position, Quaternion.identity); //Spawns Coins At 1 of the 3 Tranforms
        }
    }


}
