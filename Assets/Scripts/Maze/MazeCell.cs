using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject northWall;
    [SerializeField] private GameObject eastWall;
    [SerializeField] private GameObject southWall;
    [SerializeField] private GameObject westWall;
    private int posX;
    private int posY;
    private bool isVisited;

    public GameObject GetNorthWall()
    {
        return northWall;
    }

    public GameObject GetSouthWall()
    {
        return southWall;
    }

    public GameObject GetEastWall()
    {
        return eastWall;
    }

    public GameObject GetWestWall()
    {
        return westWall;
    }

    public void SetVisitedTrue()
    {
        this.isVisited = true;
    }

    public bool GetIsVisited()
    {
        return this.isVisited;
    }

    public int GetPosX()
    {
        return this.posX;
    }

    public int GetPosY()
    {
        return this.posY;
    }

    public void SetPos(int x, int y)
    {
        this.posX = x;
        this.posY = y;
    }

    public MazeCell GetObject()
    {
        return this;
    }


}