using System.Threading.Tasks;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    [Header("Maze grid cell container")] [SerializeField]
    private GameObject parentMazeCell;

    [Header("Prefabs")] [SerializeField] private GameObject mazeCellPrefab;


    [Header("Associations")] [SerializeField]
    public MazeData mazeData;

    private MazeCell[,] mazeGrid;

    //Algorithms
    private MazeAlgorithmBinaryTree mazeAlgorithmBinaryTree;
    private MazeAlgorithmDepthFirstSearch mazeAlgorithmDepthFirstSearch;
    private MazeAlgorithmBase selectedAlgorithm;


    void Start()
    {
        InitiliazeAlgorithms();
        SetDefaultAlgorithm();
    }


    //This method starts the generation in chronological order.
    public async Task GenerateNewMaze()
    {
       
        Debug.Log("started to generate a new maze");
        //Keeping track of the maze cell size is necessary to know the distance between maze cells
        mazeData.SetMazeCellSize(mazeCellPrefab);

        //Delete the current grid if one already exists
        if (mazeGrid != null)
        {
            await DeleteCurrentMazeGrid(parentMazeCell);
        }


        InstantiateMazeCellObjects(mazeData, mazeCellPrefab, parentMazeCell);
        StartCoroutine(selectedAlgorithm.ApplyAlgorithm(mazeGrid));
    }

    //Instantiates the maze cell game objects into the scene.
    public void InstantiateMazeCellObjects(MazeData mazeData, GameObject mazeCell, GameObject parentMazeCell)
    {
        Debug.Log("instantiating maze cell objects");
        //Retrieve maze dimensions and maze cells spacing from MazeData.
        int gridWidth = mazeData.GetMazeWidth();
        int gridHeight = mazeData.GetMazeHeight();
        float mazeCellSize = mazeData.GetMazeCellSize();

        //Initialize a new 2D maze grid array.
        this.mazeGrid = new MazeCell[gridWidth, gridHeight];
        // Set the rotation of the instantiated maze cells to face the camera.
        Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);

        //Iterate over each grid cell to instantiate and position and add the MazeCell script component.
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                // Calculate the position for the current MazeCell based on grid coordinates.
                Vector3 position = new Vector3(x * mazeCellSize, y * mazeCellSize, 0);
                GameObject mazeCellObj = Instantiate(mazeCell, position, rotation);
                mazeGrid[x, y] = mazeCellObj.GetComponent<MazeCell>();
                mazeGrid[x, y].SetPos(x, y);
                mazeCellObj.transform.SetParent(parentMazeCell.transform);
            }
        }
    }

    public async Task DeleteCurrentMazeGrid(GameObject parentMazeCell)
    {
        Debug.Log("deleting children from parentcell");
        foreach (Transform child in parentMazeCell.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void SetDefaultAlgorithm()
    {
        this.selectedAlgorithm = mazeAlgorithmDepthFirstSearch;
        Debug.Log("algorithm has been selected");
    }

    public void SetSelectedAlgorithmBinaryTree()
    {
        this.selectedAlgorithm = mazeAlgorithmBinaryTree;
    }
    
    public void SetSelectedAlgorithmDepthFirstSearch()
    {
        this.selectedAlgorithm = mazeAlgorithmDepthFirstSearch;
    }

    private void InitiliazeAlgorithms()
    {
        mazeAlgorithmDepthFirstSearch ??= parentMazeCell.AddComponent<MazeAlgorithmDepthFirstSearch>();
        mazeAlgorithmBinaryTree ??= parentMazeCell.AddComponent<MazeAlgorithmBinaryTree>();
        Debug.Log("algorithm has initialized");
    }
}