using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the direction the thrusters are pointing in.
/// </summary>
public class Spaceship_Thruster : MonoBehaviour
{
    public float RotationModifier = -1f;
    public float MinRotation = -90f;
    public float MaxRotation = 90f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateThruster();
    }

    // Rotates the object the script is attached to, the ammount of rotation is based on the speed of the ship.
    // -10 degrees of rotation for each unit of speed.
    // Min rotation -90. Max rotation 90.
    // Rotation is multiplied by the RotationModifier.
    private void RotateThruster()
    {
        float speed = GetShipSpeed();
        float rotation = speed * RotationModifier;
        rotation = Mathf.Clamp(rotation, MinRotation, MaxRotation);

        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Gets the scroll speed of the Spaceship_Rig
    private float GetShipSpeed()
    {
        Spaceship_Scroll scroll = transform.parent.parent.gameObject.GetComponent<Spaceship_Scroll>();
        float speed = scroll.Speed;
        return speed;
    }
}
