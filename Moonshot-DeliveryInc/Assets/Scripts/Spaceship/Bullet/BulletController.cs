using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls how a bullet reacts after it is fired.
/// </summary>
public class BulletController : MonoBehaviour
{
    public float ProjectileSpeed = 4f;          //Speed of the bullet.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(ProjectileSpeed, 0, 0));
    }
}
