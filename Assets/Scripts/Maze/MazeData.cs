using UnityEngine;

[CreateAssetMenu]
public class MazeData : ScriptableObject
{
    private int mazeGridWidth;
    private int mazeGridHeight;
    private float mazeCellSize;
    public void SetMazeWidth(int input)
    {
        mazeGridWidth = input;
    }
    
    public void SetMazeHeight(int input)
    {
        mazeGridHeight = input;
    }

    public void SetMazeCellSize(GameObject mazeCell)
    {
        mazeCellSize = mazeCell.transform.localScale.y;
    }

    public int GetMazeWidth()
    {
        return mazeGridWidth;
    }
    
    public int GetMazeHeight()
    {
        return mazeGridHeight;
    }
    
    public float GetMazeCellSize()
    {
        return mazeCellSize;
    }
}
