using UnityEngine;

public class ProgressBar 
{
    public static ProgressBar Instance { get; private set; }
    public ProgressBar()
    {
        if (Instance != null && Instance != this)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }
    [HideInInspector]
    public int _activityPointsToGet;  
    private float _increaseProcent;
    private float _increase;
    private float _ap;
    public void ResetProgessBar()
    {
        ProgressBar_UI.Instance.currentActivityPoints = 0;
        ProgressBar_UI.Instance.ResetProgressBarUI();
    }

    public void UpdateProgressBar(Chest chest)
    {
        _increaseProcent = _ap / _activityPointsToGet;
        _increase = 450 * _increaseProcent;
        ProgressBar_UI.Instance._currentSize += _increase;

        if (ProgressBar_UI.Instance._currentSize >= 0f)
        {
            ResetProgessBar();
            chest.ChestUnlock();
        }
    }

    public void ChangeTextOnClick(int activityPoints)
    {
        _ap = activityPoints;
        ProgressBar_UI.Instance.currentActivityPoints += activityPoints;
        if (ProgressBar_UI.Instance._currentSize >= 0)
        {
            ResetProgessBar();
        }
    }
}