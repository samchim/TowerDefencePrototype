using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Tile[,] gridMap;
    [SerializeField] private GameObject camera;

    void Start() {
        camera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        Debug.Log("hi");
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x * tilePrefab.width, y * tilePrefab.height, 0), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.transform.parent = this.transform;
                // gridMap[x, y] = spawnedTile;
            }
        }

        camera.transform.position = new Vector3(
            ((float)width/2 - 0.5f) * tilePrefab.width,
            ((float)height/2 - 0.5f) * tilePrefab.height,
            camera.transform.position.z
        );
    }

}
