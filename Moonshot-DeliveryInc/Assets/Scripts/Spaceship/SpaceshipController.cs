using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the spaceship within the rig, this affects the spaceships position relative to the camera and does not affect the scroll.
/// </summary>
public class SpaceshipController : MonoBehaviour
{
    //The maximum distance from the camera the spaceship can be (either horizontal or vertical) before the ship can be controlled to move futher away.
    //NOTE: This is not the max distance, as the ship can coast a little further after reaching this distance.
    public float MaxVerticalControlDistance = 1.75f;
    public float MaxHorizontalControlDistance = 4f;
    
    //Moonheight affects the lower bound of the MaxVerticalControlDistance.
    public float MoonHeight = 0.75f;

    //The maximum speed the spaceship can travel (not accounting for scroll).
    public float MaxVerticalSpeed = 3f;
    public float MaxHorizontalSpeed = 5f;

    //Velocity is multiplied by this value and subtracted from itself when no input is detected for a given direction, this adds to the slowing affect already applied by the rigidbody.
    public float DecelerationSpeed = 10f;

    //The rate of acceleration of the ships spe1ed when approaching the maximum speed.
    public float VerticalAcceleration = 20f;
    public float HorizontalAcceleration = 30f;

    //The ammount of rotation you get per vertical velocity of the ship, bigger = more swirly ship.
    public float ShipSwirlyness = 6f;

    //These variables affect the pitch of the thruster sound.
    public float VelocityPitchMultiplier = 0.25f;
    private AudioSource thrusterSounds;
    private float originalThrusterPitch;

    // Start is called before the first frame update
    void Start()
    {
        thrusterSounds = transform.Find("ThrusterSound").GetComponent<AudioSource>();
        originalThrusterPitch = thrusterSounds.pitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fixed update is called at a fixed interval, useful for physics stuff.
    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    // Rotate rotates the chassis of the ship in reaction to vertical movement changes.
    private void Rotate()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();

        transform.rotation = Quaternion.Euler(0, 0, rigidBody.velocity.y * ShipSwirlyness);
    }

    // Move moves the ship arround. Derp.
    private void Move()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();

        float vAcc = VerticalAcceleration * Input.GetAxis("Vertical");
        float hAcc = HorizontalAcceleration * Input.GetAxis("Horizontal");

        if (vAcc > 0f && transform.localPosition.y >= MaxVerticalControlDistance ||
            vAcc < 0f && transform.localPosition.y <= -(MaxVerticalControlDistance - MoonHeight))
        {
            vAcc = 0f;
        }

        if (hAcc > 0f && transform.localPosition.x >= MaxHorizontalControlDistance ||
            hAcc < 0f && transform.localPosition.x <= -MaxHorizontalControlDistance)
        {
            hAcc = 0f;
        }

        if (vAcc < 0.1f && vAcc > -0.1f)
        {
            float deceleration = rigidBody.velocity.y * DecelerationSpeed;
            vAcc -= deceleration;
        }

        if (hAcc < 0.1f && hAcc > -0.1f)
        {
            float deceleration = rigidBody.velocity.x * DecelerationSpeed;
            hAcc -= deceleration;
        }

        rigidBody.AddForce(new Vector2(hAcc, vAcc));

        float vSpd = Mathf.Clamp(rigidBody.velocity.y, -MaxVerticalSpeed, MaxVerticalSpeed);
        float hSpd = Mathf.Clamp(rigidBody.velocity.x, -MaxHorizontalSpeed, MaxHorizontalSpeed);
        rigidBody.velocity = new Vector2(hSpd, vSpd);

        float thrusterPitchModifier = rigidBody.velocity.magnitude * VelocityPitchMultiplier;
        thrusterSounds.pitch = originalThrusterPitch + thrusterPitchModifier;
    }
}
