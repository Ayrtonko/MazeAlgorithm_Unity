using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeAlgorithmBinaryTree : MazeAlgorithmBase
{
    //The Binary Tree algorithm : for every cell in the grid, randomly carve a path either north, or west.
    public override IEnumerator ApplyAlgorithm(MazeCell[,] mazeGrid)
    {
        //Iterate through each cell in the grid.
        for (int x = 0; x < MazeData.mazeGridWidth; x++)
        {
            for (int y = 0; y < MazeData.mazeGridHeight; y++)
            {
                // Randomly choose between 0 and 1, 0 = north and 1 = west.
                int number = Random.Range(0, 2);
                if (number == 0 && HasNorthNeighbour(mazeGrid, x, y))
                {
                    DeleteNorthMazeWall(mazeGrid, x, y);
                }

                if (number == 0 && !HasNorthNeighbour(mazeGrid, x, y) && HasWestNeighbour(mazeGrid, x, y))
                {
                    DeleteWestMazeWall(mazeGrid, x, y);
                }

                if (number == 1 && HasWestNeighbour(mazeGrid, x, y))
                {
                    DeleteWestMazeWall(mazeGrid, x, y);
                }

                if (number == 1 && !HasWestNeighbour(mazeGrid, x, y) && HasNorthNeighbour(mazeGrid, x, y))
                {
                    DeleteNorthMazeWall(mazeGrid, x, y);
                }
                yield return new WaitForSeconds(MazeData.speed);
            }
        }
    }

    bool HasNorthNeighbour(MazeCell[,] mazeGrid, int x, int y)
    {
        if (CheckWithinGrid(x, y + 1))
        {
            return true;
        }
        return false;
    }

    bool HasWestNeighbour(MazeCell[,] mazeGrid, int x, int y)
    {
        if (CheckWithinGrid(x - 1, y))
        {
            return true;
        }
        return false;
    }
}