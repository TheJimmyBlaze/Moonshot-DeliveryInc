using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls how a shell casing behaves after being ejected.
/// </summary>
public class ShellController : MonoBehaviour
{
    public float Spinnyness = -3f;       //How spinny the bullet is.
    public float EjectionSpeed = -3f;    //How fast a shell is ejected.
    public float EjectionBump = 1f;      //How much the shell is bumped upwards before falling.
    public float Randomness = 0.5f;      //The randomness imparted on both spinnyness and ejectionspeed

    // Start is called before the first frame update
    void Start()
    {
        float spinnyRandom = Random.value * Randomness - Randomness / 2;
        float speedRandom = Random.value * Randomness - Randomness / 2;
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.AddTorque(Spinnyness + spinnyRandom, ForceMode2D.Impulse);
        rigidbody.AddForce(new Vector2(EjectionSpeed + speedRandom, EjectionBump), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
