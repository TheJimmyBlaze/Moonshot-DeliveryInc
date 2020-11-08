using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destorys the muzzle flash afters it's lifespan expires.
/// </summary>
public class FlashController : MonoBehaviour
{
    public float Lifespan = 2f;         //How long the flash will sit arround before being destroyed.
    private float spawnTime;            //When the flash was spawned.

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime + Lifespan)
            Destroy(gameObject);
    }
}
