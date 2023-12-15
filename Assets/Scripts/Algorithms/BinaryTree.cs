using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BinaryTree : MazeAlgorithmBase
{
    //The Binary Tree algorithm : for every cell in the grid, randomly carve a path either north, or west.
    public override void ApplyAlgorithm(MazeCell[,] mazeGrid)
    {
        //Get the number of rows and columns in the maze grid.
        int rows = mazeGrid.GetLength(0);
        int columns = mazeGrid.GetLength(1);


        //Iterate through each cell in the grid.
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
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
            }
        }
    }

    bool HasNorthNeighbour(MazeCell[,] mazeGrid, int x, int y)
    {
        try
        {
            if (mazeGrid[x, y + 1] != null)
            {
                return true;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        return false;
    }

    bool HasWestNeighbour(MazeCell[,] mazeGrid, int x, int y)
    {
        try
        {
            if (mazeGrid[x - 1, y] != null)
            {
                return true;
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        return false;
    }
}