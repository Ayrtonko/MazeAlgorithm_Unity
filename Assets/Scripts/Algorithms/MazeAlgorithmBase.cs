using System;
using UnityEngine;

public abstract class MazeAlgorithmBase : ScriptableObject
{
    public abstract void ApplyAlgorithm(MazeCell[,] mazeGrid);

    public void DeleteNorthMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].northWall.SetActive(false);
        try
        {
            mazeGrid[x, y + 1].southWall.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void DeleteEastMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].eastWall.SetActive(false);
        try
        {
            mazeGrid[x + 1, y].westWall.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void DeleteSouthMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].southWall.SetActive(false);
        try
        {
            mazeGrid[x, y - 1].northWall.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void DeleteWestMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].westWall.SetActive(false);
        try
        {
            mazeGrid[x - 1, y].eastWall.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}