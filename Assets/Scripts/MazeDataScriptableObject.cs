using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class MazeDataScriptableObject : ScriptableObject
{
    public int mazeWidth;
    public int mazeHeight;

    void OnEnable()
    {
        this.mazeWidth = 3;
        this.mazeHeight = 3;
    }

    public void SetMazeWidth(int input)
    {
        mazeWidth = input;
    }
    
    public void SetMazeHeight(int input)
    {
        mazeHeight = input;
    }

    public int GetMazeWidth()
    {
        return mazeWidth;
    }
    
    public int GetMazeHeight()
    {
        return mazeHeight;
    }
}
