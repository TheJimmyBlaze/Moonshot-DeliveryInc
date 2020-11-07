using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{

    public int levelLength = 100;
    private float spawnLocationX = 0.0f;
    private float tileLength = 64 / 25;
    //private float tileLength = 64f / 10.0f;
    private int maxTilesRendered = 5;
    public GameObject Moon_Proto;

    // Start is called before the first frame update
    private void Start()
    {
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
        SpawnTile();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void SpawnTile()
    {
        GameObject tile = Instantiate(Moon_Proto) as GameObject;
        tile.transform.SetParent(transform);
        tile.transform.position = Vector3.right * spawnLocationX;
        spawnLocationX += tileLength;
    }
}
