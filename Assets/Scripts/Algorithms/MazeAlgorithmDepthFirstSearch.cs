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
        // Add visited cells to this list, the last cell is the selected cell.
        List<MazeCell> listMazeCells = new List<MazeCell>();

        // MazeGrid[0,0] is the start cell
        mazeGrid[0, 0].SetVisitedTrue();
        listMazeCells.Add(mazeGrid[0, 0]);

        // Loop until all maze cells are visited
        while (visitedCellsCount < MazeData.totalMazeCells - 1)
        {
            // Add all neighbours of the current cell to a list
            List<MazeCell> neighbours =
                GetCellNeighbours(mazeGrid, listMazeCells.Last().GetPosX(), listMazeCells.Last().GetPosY());

            // Generate a random number to select a random neighbor
            randomNumber = Random.Range(0, neighbours.Count);

            if (neighbours.Count > 0)
            {
                listMazeCells.Add(neighbours[randomNumber]);
                neighbours[randomNumber].SetVisitedTrue();

                // Delete the wall between the current and chosen neighbour cell
                DeleteWall(mazeGrid, listMazeCells);
                visitedCellsCount++;

                yield return new WaitForSeconds(MazeData.speed);
            }

            // If there are no available neighbors, make the previous selected cell the current selected cell.
            if (neighbours.Count < 1 && listMazeCells.Count > 1)
            {
                listMazeCells.RemoveAt(listMazeCells.Count - 1);
            }
        }
    }

    private void DeleteWall(MazeCell[,] mazeGrid, List<MazeCell> list)
    {
        // North
        if (list[^1].GetPosY() > list[^2].GetPosY() && list[^1].GetPosX() == list[^2].GetPosX())
        {
            DeleteNorthMazeWall(mazeGrid, list[^2].GetPosX(), list[^2].GetPosY());
        }

        // South
        if (list[^1].GetPosY() < list[^2].GetPosY() && list[^1].GetPosX() == list[^2].GetPosX())
        {
            DeleteSouthMazeWall(mazeGrid, list[^2].GetPosX(), list[^2].GetPosY());
        }

        // East
        if (list[^1].GetPosY() == list[^2].GetPosY() && list[^1].GetPosX() > list[^2].GetPosX())
        {
            DeleteEastMazeWall(mazeGrid, list[^2].GetPosX(), list[^2].GetPosY());
        }

        // West
        if (list[^1].GetPosY() == list[^2].GetPosY() && list[^1].GetPosX() < list[^2].GetPosX())
        {
            DeleteWestMazeWall(mazeGrid, list[^2].GetPosX(), list[^2].GetPosY());
        }
    }

    private List<MazeCell> GetCellNeighbours(MazeCell[,] mazeGrid, int x, int y)
    {
        List<MazeCell> cells = new List<MazeCell>();

        //Adjacent cell options
        int[] rowOptions = { 0, -1, 0, 1 };
        int[] colOptions = { -1, 0, 1, 0 };

        for (int i = 0; i < 4; i++)
        {
            // the coordinates for the neighbouring cell
            int posNeighbourX = mazeGrid[x, y].GetPosX() + rowOptions[i];
            int posNeighbourY = mazeGrid[x, y].GetPosY() + colOptions[i];

            // Check if the coordinates are within the grid
            if (CheckWithinGrid(posNeighbourX, posNeighbourY))
            {
                if (!mazeGrid[posNeighbourX, posNeighbourY].GetIsVisited())
                {
                    cells.Add(mazeGrid[posNeighbourX, posNeighbourY]);
                }
            }
        }

        return cells;
    }
}