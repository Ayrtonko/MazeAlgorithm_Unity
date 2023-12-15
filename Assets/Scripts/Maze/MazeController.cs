using UnityEngine;

public class MazeController : MonoBehaviour
{
    [Header("Maze grid cell container")]
    [SerializeField] private GameObject parentMazeCell;
    
    [Header("Prefabs")]
    [SerializeField] private GameObject mazeCellPrefab;
    
    
    
    [Header("Associations")]
    [SerializeField] public MazeData mazeData;
    private MazeCell[,] mazeGrid;
    
    [Header("Algorithms")]
    [SerializeField] private MazeAlgorithmBinaryTree mazeAlgorithmBinaryTree;
    private MazeAlgorithmBase selectedAlgorithm;



    void Start()
    {
        this.selectedAlgorithm = mazeAlgorithmBinaryTree;
    }



    //This method starts the generation in chronological order.
    public void GenerateNewMaze()
    {
        //Keeping track of the maze cell size is necessary to know the distance between maze cells
        mazeData.SetMazeCellSize(mazeCellPrefab);
        
        //Delete the current grid if one already exists
        if (mazeGrid != null)
        {
            DeleteCurrentMazeGrid(parentMazeCell);
        }
        InstantiateMazeCellObjects(mazeData, mazeCellPrefab, parentMazeCell);
        selectedAlgorithm.ApplyAlgorithm(mazeGrid);
    }

   //Instantiates the maze cell game objects into the scene.
    public void InstantiateMazeCellObjects(MazeData mazeData, GameObject mazeCell, GameObject parentMazeCell)
    {
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
                mazeCellObj.transform.SetParent(parentMazeCell.transform);
            }
        }
    }
    
    public void DeleteCurrentMazeGrid(GameObject parentMazeCell)
    {
        foreach (Transform child in parentMazeCell.transform)
        {
            Destroy(child.gameObject);
        }
    }
}