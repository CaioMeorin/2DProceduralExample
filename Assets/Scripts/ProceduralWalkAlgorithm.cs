using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralWalkAlgorithm
{
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength){
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        var previousPosition = startPosition; // granting that the previous position will be the starting one.
        
        for (int i = 0; i < walkLength; i++)
        {
            // Creates a new position based on the previous position, which is the start position, and adds it to path list.
            // After that, sets the new position as the previous one.
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection(); 
            path.Add(newPosition);
            previousPosition = newPosition;
        }

        return path;
    }

}



public static class Direction2D
{

    // Creates a list that will be used to choose a random step direction to our newPosition.
    public static List<Vector2Int> cardinalDirectrionsList = new List<Vector2Int>{
        new Vector2Int(0,1), // UP
        new Vector2Int(1,0), // RIGHT
        new Vector2Int(0,-1), // DOWN
        new Vector2Int(-1,0), // LEFT
    };

    // Randomly chooses one of the directions.
    public static Vector2Int GetRandomCardinalDirection(){
        return cardinalDirectrionsList[Random.Range(0,cardinalDirectrionsList.Count)];
    }

}