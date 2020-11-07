using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{

    public int levelLength = 10;
    private float spawnLocationX = 0.0f;
    private float tileLength = 64 / 25;
    //private float tileLength = 64f / 10.0f;
    private int tilesOnScreen = 5;
    public GameObject Moon;
    private Transform spaceship;
    private int tilesSpawned = 0;

    // Start is called before the first frame update
    private void Start()
    {
        
       

        spaceship = GameObject.Find("Spaceship_Rig").transform;


    }

    // Update is called once per frame
    private void Update()
    {
        if (spaceship.position.x > spawnLocationX - tilesOnScreen * tileLength && tilesSpawned < levelLength) // 5 ~ tiles that fit on the screen
        {
            SpawnTile();
            tilesSpawned++;
        }
    }

    private void SpawnTile()
    {
        GameObject tile = Instantiate(Moon) as GameObject;
        tile.transform.SetParent(transform);
        tile.transform.position = Vector3.right * spawnLocationX;
        spawnLocationX += tileLength;
    }
}
