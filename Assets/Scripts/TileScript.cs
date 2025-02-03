using UnityEngine;

public class Tile : MonoBehaviour
{
    private int tileX;
    private int tileZ;

    public void SetTileId(int x, int z)
    {
        tileX = x;
        tileZ = z;
        gameObject.name = $"Tile_{tileX}_{tileZ}";
    }

}
