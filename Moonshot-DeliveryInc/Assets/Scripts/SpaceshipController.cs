using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float Speed = 1.0f;  // Distance modifier, defaults to 1.

    public float ShootSpeed = 1.0f; // Speed at which bullets can be shot, defaults to 1. Larger values are slower.
    public GameObject Bullet; // The bullet object to spawn when shooting.

    private float lastShot = 0; // Last time we shot a bullet.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Do moving
        float xShift = Speed * Time.deltaTime;
        float yShift = 0;   //This will be acted upon if an input is detected.

        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log($"Vertical: {verticalInput}");

        yShift = verticalInput * Time.deltaTime;

        transform.Translate(xShift, yShift, 0);

        //Do shooting
        if (Input.GetAxis("Shooting") > 0)
        {
            if (Time.time > lastShot + ShootSpeed)
            {
                lastShot = Time.time;

                Vector3 bulletSpawnLocation = transform.position;
                bulletSpawnLocation.x += 0.55f;
                bulletSpawnLocation.y += -0.1f;

                GameObject.Instantiate(Bullet, bulletSpawnLocation, Quaternion.identity, transform.parent);
            }
        }
    }
}
