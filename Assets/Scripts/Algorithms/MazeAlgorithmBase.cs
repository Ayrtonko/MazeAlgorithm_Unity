using System;
using UnityEngine;

public abstract class MazeAlgorithmBase : ScriptableObject
{
    public abstract void ApplyAlgorithm(MazeCell[,] mazeGrid);

    public void DeleteNorthMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].GetNorthWall().SetActive(false);
        try
        {
            mazeGrid[x, y + 1].GetSouthWall().SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void DeleteEastMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].GetEastWall().SetActive(false);
        try
        {
            mazeGrid[x + 1, y].GetWestWall().SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void DeleteSouthMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].GetSouthWall().SetActive(false);
        try
        {
            mazeGrid[x, y - 1].GetNorthWall().SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void DeleteWestMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        mazeGrid[x, y].GetWestWall().SetActive(false);
        try
        {
            mazeGrid[x - 1, y].GetEastWall().SetActive(false);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}