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

    //Affects how much the camera jiggles in response to various things.
    public float MaxJigglyness = 2f;
    public float JiggleDecay = 0.1f;
    public float ShotJiggle = 1f;

    private float jigglyness = 0f;  //Stores the current Jigglyness.
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    //This is called by others to make the camera jiggle.
    public void AddJiggle(float jiggle)
    {
        jigglyness += jiggle;
    }

    // Update is called once per frame
    void Update()
    {
        RespondToMove();
        DoJiggle();
    }

    // Handles camera jigglyness.
    private void DoJiggle()
    {
        if (jigglyness > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * jigglyness;
            jigglyness -= Time.deltaTime * JiggleDecay;
        }
        else
        {
            jigglyness = 0f;
            transform.localPosition = originalPosition;
        }
    }

    // RespondToMove wiggles the camera arround when the ship is moving.
    private void RespondToMove()
    {
        Rigidbody2D ship = transform.parent.Find("Spaceship_Chassis").GetComponent<Rigidbody2D>();

        transform.localPosition = ship.velocity * MovementWiggle;
    }
}
