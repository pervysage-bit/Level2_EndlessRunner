using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    // idle (player is alive)
    bool alive = true;
    
    // forward speed of player
    public float speed = 5;
    
    // rigidbody type variable
    public Rigidbody rb;
    
    // right and left input for player
    float horizontalInput;

    // R & L speed setter
    public float horizontalMultiplier = 2;

    
    void FixedUpdate()
    {
        // if player not alive not run the function
        if (!alive)
        {
            return;
        }

        // forward move is multipple by tranform of player, speed of player, fixed deltatime
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;

        // R & L move: multiple by transform position x-axis,  speed of player, fixed deltatime
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

        // rigidbody variable used for rb position, forward and horizontal move.
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        // built in function Getaxis is used and horizontal parameter for R & L movement
        horizontalInput = Input.GetAxis("Horizontal");

        // if the player fell off the ground
        if(transform.position.y < -5)
        {
            Die();
        }
    }

    // player death method and game restart built in import used scene manager
    public void Die()
    {
        alive = false;
       
        //delay for restart
        Invoke("Restart", 1);

        

       
    }
   
    
    //restart the game
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
