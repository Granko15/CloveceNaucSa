using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tilePrefab;  // Reference to the tile prefab
    public int gridWidth = 5;      // Number of tiles horizontally
    public int gridHeight = 5;     // Number of tiles vertically
    public float tileSize = 1.1f;  // Size of each tile with padding

    private List<GameObject> tiles = new List<GameObject>();

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                // Calculate the position of the tile
                Vector3 tilePosition = new Vector3(x * tileSize, 0, z * tileSize);

                // Instantiate the tile prefab at the calculated position
                GameObject tile = Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                tile.name = $"Tile_{x}_{z}";  // Name the tile for easy debugging

                // Optional: Assign the tile an ID for game logic
                Tile tileScript = tile.GetComponent<Tile>();
                if (tileScript != null)
                {
                    tileScript.SetTileId(x, z);
                }

                // Add the tile to the list for future use (e.g., game logic)
                tiles.Add(tile);
            }
        }

        Debug.Log($"Generated {gridWidth * gridHeight} tiles.");
    }
}
