using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // gameobject type, ground tile variable
    public GameObject groundTile;

    // private vector3 type, nextspawnpoint variable
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        // Instantiate meaning Spawn,
        // 1st input is the object you r spawn, 2nd input is where we want to spawn, 3rd  rotation of it 'simply means no rotation'.
       GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);

        // next spawn point is getting value of transform of GroundSpawner, 
        //       getChild(1) because nextspawnPoint is on 1 index, positon of ground spawner
       nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //loop is used for spawn tiles
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
       
    }
}
