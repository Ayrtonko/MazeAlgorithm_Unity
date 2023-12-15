using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject northWall;
    [SerializeField] private GameObject eastWall;
    [SerializeField] private GameObject southWall;
    [SerializeField] private GameObject westWall;
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
}
