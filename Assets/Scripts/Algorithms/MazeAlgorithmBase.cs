using System;
using System.Collections;
using UnityEngine;

public abstract class MazeAlgorithmBase : MonoBehaviour
{

    public abstract IEnumerator ApplyAlgorithm(MazeCell[,] mazeGrid);

    public void DeleteNorthMazeWall(MazeCell[,] mazeGrid, int x, int y)
    {
        try
        {
            mazeGrid[x, y].GetNorthWall().SetActive(false);

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
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
        try
        {
            mazeGrid[x, y].GetEastWall().SetActive(false);

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
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
        try
        {
            mazeGrid[x, y].GetSouthWall().SetActive(false);

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
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
        try
        {
            mazeGrid[x, y].GetWestWall().SetActive(false);

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
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