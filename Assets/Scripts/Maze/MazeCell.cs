using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] public GameObject northWall;
    [SerializeField] public GameObject eastWall;
    [SerializeField] public GameObject southWall;
    [SerializeField] public GameObject westWall;
    private bool isVisited;
}
