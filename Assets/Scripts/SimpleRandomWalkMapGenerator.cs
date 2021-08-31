using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomWalkMapGenerator : MonoBehaviour
{
 
 
    // Start is called before the first frame update
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero; // Starting position at (0,0) theoretically at the center of the map


    // Characteristics
    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;


    [SerializeField]
    private TilemapVisualizer tilemapVisualizer;


    // Clears the tilemap, then,
    // Runs the method that creates the floor's position
    public void RunProceduralGeneration(){
        //Create the floor position

        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
    }


    protected HashSet<Vector2Int> RunRandomWalk(){

        // Creates the floor's position running as many iterations as defined at the variable iterations
        // Then, adds the current position to the floorPositions list, and, if startRandomlyEachIteration
        // is set to true, it will make sure that a random position will be choosen from the list, returning
        // it at the end.


        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

        for (int i = 0; i < iterations; i++)
        {
            var path = ProceduralWalkAlgorithm.SimpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);

            if (startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }

        return floorPositions;
    }

}
