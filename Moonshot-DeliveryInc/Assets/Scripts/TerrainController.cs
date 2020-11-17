using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{

    public int levelLength = 10;
    private float spawnLocationX = 0.0f;
    private int tilesOnScreen = 6;
    public GameObject[] MoonTiles;
    private Transform spaceship;
    private int tilesSpawned = 0;

    private List<GameObject> activeTiles;
    private float baseTileSize;

    // Start is called before the first frame update
    private void Start()
    {
        activeTiles = new List<GameObject>();
        spaceship = GameObject.Find("Spaceship_Rig").transform;
        baseTileSize = MoonTiles[0].GetComponent<SpriteRenderer>().size.x; // Sort of need all the tiles to be the same size for this

        //initial load
        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (spaceship.position.x - 7 > (spawnLocationX - tilesOnScreen * baseTileSize) && tilesSpawned < levelLength) // 5 ~ tiles that fit on the screen
        {
            SpawnTile();
            tilesSpawned++;
            DespawnTile();
        } 
    }

    private void SpawnTile()
    {
       
        var randomTileIndex = Random.Range(0, MoonTiles.Length);
        var tile = Instantiate(MoonTiles[randomTileIndex], Vector3.right * spawnLocationX, Quaternion.identity, transform);
        spawnLocationX += MoonTiles[randomTileIndex].GetComponent<SpriteRenderer>().size.x;
        activeTiles.Add(tile);
    }

    private void DespawnTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
