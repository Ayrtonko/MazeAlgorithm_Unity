using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    [SerializeField] private MazeData mazeData;
    [SerializeField] private GameObject userInterface;
    [SerializeField] private MazeController mazeController;
    [SerializeField] private CameraController cameraController;
    private UIControllerLogic userInterfaceLogic;
    
    //UI objects   
    [SerializeField] private TMP_InputField inputMazeWidth;
    [SerializeField] private TMP_InputField inputMazeHeight;
    [SerializeField] private Button generateButton;
    void Start()
    {
        userInterfaceLogic ??= new();
        generateButton.onClick.AddListener(GenerateButtonOnClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            userInterfaceLogic.ToggleMenu(userInterface);
        }

    }

    //When the user presses Generate.
    public void GenerateButtonOnClick()
    {
        int mazeHeight = userInterfaceLogic.InputFieldToInt(this.inputMazeHeight);
        int mazeWidth = userInterfaceLogic.InputFieldToInt(this.inputMazeWidth);
        mazeData.SetMazeHeight(mazeHeight);
        mazeData.SetMazeWidth(mazeWidth);
        if (userInterfaceLogic.CheckValidInput(this.inputMazeWidth, this.inputMazeHeight))
        {
            userInterfaceLogic.HideMenu(userInterface);
            mazeController.GenerateNewMaze();
            StartCoroutine(DelayedCameraPosition());
        }
    }

    IEnumerator DelayedCameraPosition()
    {
        yield return new WaitForSeconds(0.1f);
        cameraController.SetCameraPosition();
    }
    
}
