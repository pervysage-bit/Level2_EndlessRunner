using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // built in function called automatically what we doing is we killing the player in this method
    void OnCollisionEnter(Collision collision)
    {
        // this check if the object that collided with the obstacle is player 
        if(collision.gameObject.name == "Player")
        {
            // if it is then player die
            playerMovement.Die();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
