using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the scrolling speed of the Spaceship_Rig.
/// Does NOT control the movement of the spaceship in relation to the camera.
/// </summary>
public class Spaceship_Scroller : MonoBehaviour
{
    [Range(-12f, 12f)]
    public float Speed = 1f;        //Speed at which the rig scrolls to the right.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movement = Speed * Time.deltaTime;
        transform.Translate(movement, 0, 0);
    }
}
