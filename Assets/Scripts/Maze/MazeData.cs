using UnityEngine;

[CreateAssetMenu]
public class MazeData : ScriptableObject
{
    public static int mazeGridWidth;
    public static int mazeGridHeight;
    public static int totalMazeCells;
    private float mazeCellSize;
    public static float speed = 0.02f;
    public void SetMazeProps(int width, int height)
    {
        mazeGridWidth = width;
        mazeGridHeight = height;
        totalMazeCells = width * height;
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
