using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Takes an object as a thing to follow
    public Transform Player;
    private float offset = -5;
    public Transform follow;
    public Camera cam;

    public Vector3[]
        spawnPoints;

    private void Start()
    {

    }

    //Called once a frame
    void FixedUpdate()
    {
        if(follow == null)
        {
            follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
        //Moves the camera to follow the player
        transform.position = new Vector3(follow.position.x + offset, 0, follow.position.z + offset);
    }

}