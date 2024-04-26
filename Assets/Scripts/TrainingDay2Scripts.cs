using System;
using UnityEngine;

public class TrainingDay2Scripts : MonoBehaviour
{
    [SerializeField]
    private int pressCount = 0;
    [SerializeField]
    private GameObject taskButton;
    public void Start()
    {
        pressCount = PlayerPrefs.GetInt("pressCount");
    }
    public void InstantiateObject()
    {
        taskButton = Instantiate(taskButton);
    }
    public void LogObjectName()
    {
        Debug.Log(taskButton.name);
    }

    public void LogButtonPressCount() 
    {
        pressCount++;
        Debug.Log(pressCount);
        PlayerPrefs.SetInt("pressCount",pressCount);
    }
}