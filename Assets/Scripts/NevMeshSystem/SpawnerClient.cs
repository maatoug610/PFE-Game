using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerClient : MonoBehaviour
{
    
    public GameObject[] Client;
    public Transform[] SpawnPoint;
    public float IntervalBetweenSpawn;
    private float spawnBetweenTime;
 

    // Update is called once per frame
    void FixedUpdate()
    {
       if(spawnBetweenTime <= 0){
           int rand = Random.Range(0,Client.Length);
           int randSpawn = Random.Range(0,SpawnPoint.Length);
           Instantiate(Client[rand],SpawnPoint[randSpawn].position, Quaternion.identity);
           spawnBetweenTime = IntervalBetweenSpawn;
       }
       else{
           spawnBetweenTime -= Time.deltaTime;
       }
    }

    
}
