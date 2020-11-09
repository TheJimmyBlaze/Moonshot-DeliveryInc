using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Switches between the flash animation frames, destorying the object after all frames are cycled.
/// </summary>
public class FlashController : MonoBehaviour
{
    public Sprite[] FlashSprites;       //The sprites to cycle through.
    public float Lifespan = 2f;         //How long each frame of the flash animation will last.
    private float spawnTime;            //When the flash was spawned.

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        int frameIndex = (int)((Time.time - spawnTime) / Lifespan);
        if (frameIndex >= FlashSprites.Length)
        {
            Destroy(gameObject);
            return;
        }

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = FlashSprites[frameIndex];
    }
}
