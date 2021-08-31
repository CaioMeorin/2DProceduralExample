using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{

    [SerializeField]
    private Tilemap floorTilemap;
    [SerializeField]
    private TileBase floorTile;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        // Calls the method that paints multiple tiles, based on PaintSingleTile function.
        PaintTiles(floorPositions, floorTilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        // Iterates through the amount of positions and calls the method that paints a single tile in the current position
        foreach(var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        // Converts the position of a single tile to a World related position and sets it at the respective position
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear()
    {
        // Clears the generated tiles
        floorTilemap.ClearAllTiles();
    }
}
