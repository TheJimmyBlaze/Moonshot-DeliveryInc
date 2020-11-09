using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the camera attached to the ship rig. Makes it wiggle arround when stuff happens.
/// </summary>
public class SpaceshipCamera : MonoBehaviour
{
    //Affects the ammount the camera is wiggled when moving.
    public float MovementWiggle = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RespondToMove();
    }

    // RespondToMove wiggles the camera arround when the ship is moving.
    private void RespondToMove()
    {
        Rigidbody2D ship = transform.parent.Find("Spaceship_Chassis").GetComponent<Rigidbody2D>();

        transform.localPosition = ship.velocity * MovementWiggle;
    }
}
