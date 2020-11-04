using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Bullet should be spawned at 0.55, -0.1 relative to spaceship.

    public float Speed = 10; // How fast does the bullet move, defaults to 10.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xShift = Speed * Time.deltaTime;
        transform.Translate(xShift, 0, 0);

        GameObject owner = transform.parent.gameObject;
        if (transform.position.x > owner.transform.position.x + 10)
            Destroy(gameObject);
    }
}
