using System;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    private float mazeCellMargin;
    [SerializeField] private GameObject parentMazeCell;
    [SerializeField] private GameObject myMazeCell;
    [SerializeField] private MazeDataScriptableObject mazeData;

    private MazeCell[,] mazeGrid;
    private List<MazeCell[,]> mazeArray;

    //localScale is used to set the margin between MazeCells, so when you increase the size of a MazeCell by adjusting the scale
    //the distance between MazeCells will remain the same.
    void Start()
    {
        mazeCellMargin = myMazeCell.transform.localScale.y;
        GenerateMaze();
        BinaryTree tree = new BinaryTree();
        tree.RemoveMazeCellWalls(this.mazeGrid);
    }

    void Update()
    {
    }

    void GenerateMaze()
    {
        InstantiateMazeCellObjects();
    }

    void InstantiateMazeCellObjects()
    {
        int gridWidth = mazeData.GetMazeWidth();
        int gridHeight = mazeData.GetMazeHeight();

        this.mazeGrid = new MazeCell[gridWidth, gridHeight];
        Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);

        // Calculate the position for the current MazeCell based on grid coordinates and store the MazeCell component of the instantiated object in the mazeGrid array.
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Vector3 position = new Vector3(x * mazeCellMargin, y * mazeCellMargin, 0);
                GameObject mazeCellObj = Instantiate(myMazeCell, position, rotation);
                mazeGrid[x, y] = mazeCellObj.GetComponent<MazeCell>();
                mazeCellObj.transform.SetParent(parentMazeCell.transform);
            }
        }
    }

    void DeleteNorthMazeWall(int x, int y)
    {
        mazeGrid[x, y].northWall.SetActive(false);
        try
        {
            mazeGrid[x, y + 1].southWall.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    void DeleteEastMazeWall(int x, int y)
    {
        mazeGrid[x, y].eastWall.SetActive(false);
        try
        {
            mazeGrid[x + 1, y].westWall.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    void DeleteSouthMazeWall(int x, int y)
    {
        mazeGrid[x, y].southWall.SetActive(false);
        try
        {
            mazeGrid[x, y - 1].northWall.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    void DeleteWestMazeWall(int x, int y)
    {
        mazeGrid[x, y].westWall.SetActive(false);
        try
        {
            mazeGrid[x - 1, y].eastWall.SetActive(false);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}