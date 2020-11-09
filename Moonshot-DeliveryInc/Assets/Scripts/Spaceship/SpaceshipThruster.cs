using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the direction the thrusters are pointing in.
/// </summary>
public class SpaceshipThruster : MonoBehaviour
{
    public float RotationModifier = -1f;        //The ammount the thrusters rotates based on speed.
    public float MinRotation = -90f;            //The minimum possible rotation of this truster (usually -90).
    public float MaxRotation = 90f;             //The maximum possible rotation fo this truster (usually +90).

    public float WobbleSpeed = 0.1f;
    public float MaxWobble = 2f;

    private float currentWobble = 0f;
    private bool isWobbleFlipped = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateThruster();
        AdjustThrust();
    }

    // Rotates the object the script is attached to, the ammount of rotation is based on the speed of the ship.
    // -10 degrees of rotation for each unit of speed.
    // Min rotation -90. Max rotation 90.
    // Rotation is multiplied by the RotationModifier.
    private void RotateThruster()
    {
        float speed = GetShipSpeed().x;
        float rotation = speed * RotationModifier;
        rotation = Mathf.Clamp(rotation, MinRotation, MaxRotation);

        rotation += GetThrusterWobble();
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    private float GetThrusterWobble()
    {
        float adjustedWobble = WobbleSpeed;
        if (isWobbleFlipped)
            adjustedWobble *= -1;

        currentWobble += adjustedWobble;
        if (currentWobble > MaxWobble ||
            currentWobble < -MaxWobble)
            isWobbleFlipped = !isWobbleFlipped;

        return currentWobble;
    }

    // Controls which thruster sprite is being used to indicate thruster power.
    // When going up the thruster should have a large beam.
    // When staying at the same height the truster should have a medium beam.
    // When going down the trhsuter should have a small beam.
    private void AdjustThrust()
    {
        GameObject small = transform.Find("SmallThrust").gameObject;
        GameObject medium = transform.Find("MediumThrust").gameObject;
        GameObject large = transform.Find("LargeThrust").gameObject;

        small.SetActive(false);
        medium.SetActive(false);
        large.SetActive(false);

        float speed = GetShipSpeed().y;
        if (speed > 0.5f)
        {
            large.SetActive(true);
        }
        else if (speed < -0.5f)
        {
            small.SetActive(true);
        }
        else
        {
            medium.SetActive(true);
        }
    }

    // Gets the scroll speed of the Spaceship_Rig
    private Vector2 GetShipSpeed()
    {
        SpaceshipScroller scroll = transform.parent.parent.gameObject.GetComponent<SpaceshipScroller>();
        Rigidbody2D ship = transform.parent.gameObject.GetComponent<Rigidbody2D>();

        Vector2 speed = new Vector2(scroll.Speed + ship.velocity.x, ship.velocity.y);
        return speed;
    }
}
