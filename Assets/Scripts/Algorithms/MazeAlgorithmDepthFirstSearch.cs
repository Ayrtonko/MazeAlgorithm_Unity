using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MazeAlgorithmDepthFirstSearch : MazeAlgorithmBase
{
    private int visitedCellsCount;
    private int randomNumber;

    public override IEnumerator ApplyAlgorithm(MazeCell[,] mazeGrid)
    {
        visitedCellsCount = 0;
        Debug.Log("executing dfs algorithm");
        List<MazeCell> listMazeCells = new List<MazeCell>();
        mazeGrid[0, 0].SetVisitedTrue();
        listMazeCells.Add(mazeGrid[0, 0]);

        while (visitedCellsCount < MazeData.totalMazeCells - 1)
        {
            Debug.Log("visited cells: " + visitedCellsCount);
            var neighbours =
                GetCellNeighbours(mazeGrid, listMazeCells.Last().GetPosX(), listMazeCells.Last().GetPosY());
            randomNumber = Random.Range(0, neighbours.Count);
            
            if (neighbours.Count > 0)
            {
                listMazeCells.Add(neighbours[randomNumber]);
                neighbours[randomNumber].SetVisitedTrue();
                DeleteWall(mazeGrid, listMazeCells);
                visitedCellsCount++;
                yield return new WaitForSeconds(MazeData.speed);
            }

            if (neighbours.Count < 1 && listMazeCells.Count > 2)
            {
                listMazeCells.RemoveAt(listMazeCells.Count - 1);
            }
            
        }
        
    }

    private void DeleteWall(MazeCell[,] mazeGrid, List<MazeCell> list)
    {
        Debug.Log("Deleting a wall");
        //UP
        if (list[^1].GetPosY() > list[^2].GetPosY() && list[^1].GetPosX() == list[^2].GetPosX())
        {
            DeleteNorthMazeWall(mazeGrid, list[^2].GetPosX(), list[^2].GetPosY());
        }

        //Down
        if (list[^1].GetPosY() < list[^2].GetPosY() && list[^1].GetPosX() == list[^2].GetPosX())
        {
            DeleteSouthMazeWall(mazeGrid, list[^2].GetPosX(), list[^2].GetPosY());
        }

        // Right
        if (list[^1].GetPosY() == list[^2].GetPosY() && list[^1].GetPosX() > list[^2].GetPosX())
        {
            DeleteEastMazeWall(mazeGrid, list[^2].GetPosX(), list[^2].GetPosY());
        }

        // Left
        if (list[^1].GetPosY() == list[^2].GetPosY() && list[^1].GetPosX() < list[^2].GetPosX())
        {
            DeleteWestMazeWall(mazeGrid, list[^2].GetPosX(), list[^2].GetPosY());
        }
    }

    private List<MazeCell> GetCellNeighbours(MazeCell[,] mazeGrid, int x, int y)
    {
        Debug.Log("retrieving neighbour cells");

        List<MazeCell> cells = new List<MazeCell>();
        int rowsTotal = MazeData.mazeGridWidth;
        int colsTotal = MazeData.mazeGridHeight;

        //Adjacent cell options
        int[] rowOptions = { 0, -1, 0, 1 };
        int[] colOptions = { -1, 0, 1, 0 };

        for (int i = 0; i < 4; i++)
        {
            int cellRow = mazeGrid[x, y].GetPosX() + rowOptions[i];
            int cellCol = mazeGrid[x, y].GetPosY() + colOptions[i];

            // Check if the new coordinates are within the bounds of the array
            if (cellRow >= 0 && cellRow < rowsTotal && cellCol >= 0 && cellCol < colsTotal)
            {
                if (!mazeGrid[cellRow, cellCol].GetIsVisited())
                {
                    cells.Add(mazeGrid[cellRow, cellCol]);
                }
            }
        }

        return cells;
    }
}