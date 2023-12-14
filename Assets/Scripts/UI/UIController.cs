using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputMazeWidth;
    [SerializeField] private TMP_InputField inputMazeHeight;
    [SerializeField] private Button generateButton;
    
    [SerializeField] private MazeDataScriptableObject mazeData;
    void Start()
    {
        generateButton.onClick.AddListener(GenerateButtonOnClick);
    }
    
    void Update()
    {

    }

    public void GenerateButtonOnClick()
    {
        mazeData.SetMazeHeight(InputFieldMazeHeightToInt());
        mazeData.SetMazeWidth(InputFieldMazeWidthToInt());
    }

    public int InputFieldMazeWidthToInt()
    {
        try
        {
            return int.Parse(inputMazeWidth.text);
        }
        catch (Exception e)
        {
            Debug.Log("SetInputMazeWidth Error, " + e);
        }
        return 0;
    }
    
    public int InputFieldMazeHeightToInt()
    {
        try
        { 
            return int.Parse(inputMazeHeight.text);
        }
        catch (Exception e)
        {
            Debug.Log("SetInputMazeHeight Error, " + e);
        }
        return 0;
    }
}
