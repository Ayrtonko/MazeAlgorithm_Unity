using System;
using System.Collections;
using UnityEngine;

public abstract class MazeAlgorithmBase : MonoBehaviour
{
    public abstract IEnumerator ApplyAlgorithm(MazeCell[,] mazeGrid);

    public void DeleteNorthMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].GetNorthWall().SetActive(false);
        if (CheckWithinGrid(x, y + 1))
        {
            mazeGrid[x, y + 1].GetSouthWall().SetActive(false);
        }
    }

    public void DeleteEastMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].GetEastWall().SetActive(false);
        if (CheckWithinGrid(x + 1, y))
        {
            mazeGrid[x + 1, y].GetWestWall().SetActive(false);
        }
    }

    public void DeleteSouthMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].GetSouthWall().SetActive(false);
        if (CheckWithinGrid(x, y - 1))
        {
            mazeGrid[x, y - 1].GetNorthWall().SetActive(false);
        }
    }

    public void DeleteWestMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].GetWestWall().SetActive(false);
        if (CheckWithinGrid(x - 1, y))
        {
            mazeGrid[x - 1, y].GetEastWall().SetActive(false);
        }
    }

    public bool CheckWithinGrid(int cellRow, int cellCol)
    {
        return cellRow >= 0 && cellRow < MazeData.mazeGridWidth && cellCol >= 0 && cellCol < MazeData.mazeGridHeight;
    }
}