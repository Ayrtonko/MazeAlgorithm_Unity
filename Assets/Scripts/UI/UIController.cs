using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private MazeData mazeData;
    [SerializeField] private GameObject userInterface;
    [SerializeField] private MazeController mazeController;
    [SerializeField] private CameraController cameraController;

    //UI objects   
    [SerializeField] private TMP_InputField inputMazeWidth;
    [SerializeField] private TMP_InputField inputMazeHeight;
    [SerializeField] private Button generateButton;
    void Start()
    {
        generateButton.onClick.AddListener(GenerateButtonOnClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu(userInterface);
        }

    }

    //When the user presses generate.
    public void GenerateButtonOnClick()
    {
        int mazeHeight = InputFieldToInt(this.inputMazeHeight);
        int mazeWidth = InputFieldToInt(this.inputMazeWidth);
        mazeData.SetMazeHeight(mazeHeight);
        mazeData.SetMazeWidth(mazeWidth);
        
        if (CheckValidInput(this.inputMazeWidth, this.inputMazeHeight))
        {
            mazeController.GenerateNewMaze();
            HideMenu(userInterface);
            cameraController.SetCameraPosition();
            StartCoroutine(cameraController.SetCameraPositionDelayed());
        }
    }
    
    //Checks if the user input is valid and meet the requirements.
    public bool CheckValidInput(TMP_InputField inputMazeWidth, TMP_InputField inputMazeHeight)
    {
        if (string.IsNullOrWhiteSpace(inputMazeWidth.text) || string.IsNullOrWhiteSpace(inputMazeHeight.text))
        {
            return false;
        }
        
        if ((InputFieldToInt(inputMazeWidth) > 250 ) || (InputFieldToInt(inputMazeWidth) < 10))
        {
            return false;
        }
        
        if ((InputFieldToInt(inputMazeHeight) > 250 ) || (InputFieldToInt(inputMazeHeight) < 10))
        {
            return false;
        }
        
        return true;
    }

    public void ToggleMenu(GameObject userInterface)
    {
        bool menuIsActive = userInterface.activeSelf;
        if (menuIsActive)
        {
            userInterface.SetActive(false);
        }
        else
        {
            userInterface.SetActive(true);
        }
    }
    public void HideMenu(GameObject userInterface)
    {
        userInterface.SetActive(false);
    }

    public int InputFieldToInt(TMP_InputField input)
    {
        try
        {
            return int.Parse(input.text);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        return 0;
    }


    
}
