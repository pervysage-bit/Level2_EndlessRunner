using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // transform type player variable
    public Transform player;

    // vectpr3 type offset variable
    public Vector3 offset;



    void Start()
    {
        // transform of camera position - tranform of player position
        // static camera for player
        offset = transform.position - player.position;
    }
    // Update is called once per frame
    void Update()
    {
        //transform is used refer to the object where script is sittin.
        //transform is used for camera position.
        // and equal to player so both have same values now.
        // offset: 3 x 3, position of player x offset of camera

        // transform.position = player.position + offset; // 'brackey line of code'
        
        // targetPos is used for camera to not move on x axis while player is moving left and right.
        Vector3 targetpos = player.position + offset;
        targetpos.x = 0;
        transform.position = targetpos;

    }
}
