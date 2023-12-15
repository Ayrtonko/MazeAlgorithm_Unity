using UnityEngine;

[CreateAssetMenu]
public class MazeData : ScriptableObject
{
    public static int mazeWidth;
    public static int mazeHeight;
    public static float mazeCellSize;
    public void SetMazeWidth(int input)
    {
        mazeWidth = input;
    }
    
    public void SetMazeHeight(int input)
    {
        mazeHeight = input;
    }

    public void SetMazeCellSize(GameObject mazeCell)
    {
        mazeCellSize = mazeCell.transform.localScale.y;
    }

    public int GetMazeWidth()
    {
        return mazeWidth;
    }
    
    public int GetMazeHeight()
    {
        return mazeHeight;
    }
    
    public float GetMazeCellSize()
    {
        return mazeCellSize;
    }
}
