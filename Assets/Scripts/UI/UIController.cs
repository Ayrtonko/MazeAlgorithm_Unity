using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject userInterface;
    [SerializeField] private TMP_InputField inputMazeGridWidth;
    [SerializeField] private TMP_InputField inputMazeGridHeight;
    [SerializeField] private Button generateButton;
    
    [Header("Associations")]
    [SerializeField] private MazeController mazeController;
    [SerializeField] private CameraController cameraController;
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
        int mazeHeight = InputFieldToInt(this.inputMazeGridHeight);
        int mazeWidth = InputFieldToInt(this.inputMazeGridWidth);
        mazeController.mazeData.SetMazeHeight(mazeHeight);
        mazeController.mazeData.SetMazeWidth(mazeWidth);
        
        if (CheckValidInput(this.inputMazeGridWidth, this.inputMazeGridHeight))
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

    public void ToggleMenu(GameObject ui)
    {
        bool menuIsActive = ui.activeSelf;
        if (menuIsActive)
        {
            ui.SetActive(false);
        }
        else
        {
            ui.SetActive(true);
        }
    }
    public void HideMenu(GameObject ui)
    {
        ui.SetActive(false);
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
