using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // speed for coin rotation. coin will rotate 90 degree every 1 sec
    public float turnSpeed = 90;



    void OnTriggerEnter(Collider other)
    {

        // obstacles and coins collide with each other, coin will destroy itself
        if(other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }



        //check the object we collided is player or not.
        if (other.gameObject.name != "Player")
        {
            return;
        }
        // add to the player score

        // and destroy the coin that collide with player
        //game object refer to the coins.
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation axis set for coins
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
