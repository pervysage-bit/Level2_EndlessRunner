using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// in this class the ground tiles is destroy when player move forward and add one in front of player bcz of loop. 
public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
        SpawnCoins();
    }

    void OnTriggerExit (Collider other)
    {
        // calling SpawnTile from groundSpawner class
        groundSpawner.SpawnTile();

        // its will destroy gameObject(Groundsapmner (line 13) ) after 1 seconds of player move to next tile.
        Destroy(gameObject, 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // variable for obstacle
    public GameObject obstaclePrefab;

    //method for random obstacle spawn
    void SpawnObstacle()
    {

        // choose a random spawn point.
        
        int obstacleSpawnIndex = Random.Range(2, 5);

        //1st transform is for this gameObject (gametile) and 2nd tansform is for child of that game object.
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        
        // Spawn the obstacle at that position.
        // inputs in instantiate: 1st: what we are spawning, 2nd: its position, 3rd: no rotation, 4th game object transform values
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinstoSpawn = 4;
        for (int i = 0; i < coinstoSpawn; i++)
        {
            // instantiate fancy way of saying spawn , as here transform refer to parent and its ground tile,
           GameObject temp =  Instantiate(coinPrefab, transform);

            // will get it soon xd setting the position of spawncoins equal to GetRandomPointInCollider.
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }

        // to get random position we need complex method 

        Vector3 GetRandomPointInCollider(Collider collider)
        {
            //in this method we are using collider bounder,
            Vector3 point = new Vector3(
                Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                Random.Range(collider.bounds.min.z, collider.bounds.max.z));

            //in this if statement, we check whether the coins are spawn on the ground tile or not if not if statement will run and get random number till he gets the number that on the ground tile.
            if(point != collider.ClosestPoint(point))
            {
                point = GetRandomPointInCollider(collider);
            }

            // this will do that all coins spawn at same height
            point.y = 1;

            return point;
        }
    }
}
