using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{    
    public static ProgressBar Instance;
    public ProgressBar()
    {
        Instance = this;
    }

    [HideInInspector] 
    public int currentActivityPoints;
    public Image progressBar;
    public TMP_Text currentActivityPointsText;   
    private float _increaseProcent;
    private float _increase;
    private float _currentSize = -450;
    private float _ap;
    
    public void Start()
    {
        _currentSize = PlayerPrefs.GetFloat("currentSize");
        currentActivityPointsText.text = PlayerPrefs.GetInt("currentActivityPoints").ToString();
        currentActivityPoints = PlayerPrefs.GetInt("currentActivityPoints");
        progressBar.rectTransform.offsetMax = new Vector2(_currentSize, -5);
    }
    public void ResetProgessBar()
    {      
        currentActivityPoints = 0;
        currentActivityPointsText.text = currentActivityPoints.ToString();
        _currentSize = -450;       
        progressBar.rectTransform.offsetMax = new Vector2(_currentSize, -5);
        PlayerPrefs.SetFloat("currentSize",_currentSize);
        PlayerPrefs.SetInt("currentActivityPoints",currentActivityPoints);
    }

    public void UpdateProgressBar(Chest chest)
    {
        _increaseProcent =  _ap / chest.activityPointsToGet;
        _increase = 450 * _increaseProcent;       
        progressBar.rectTransform.offsetMax = new Vector2(_currentSize + _increase, -5);
        _currentSize = _currentSize + _increase;

        if (_currentSize >= 0f)
        {
            ResetProgessBar();
            chest.ChestUnlock();
        }
        PlayerPrefs.SetFloat("currentSize", _currentSize);
    }

    public void ChangeTextOnClick(int activityPoints)
    {
        _ap = activityPoints;
        currentActivityPointsText.text = (currentActivityPoints + activityPoints).ToString();
        currentActivityPoints += activityPoints;
        PlayerPrefs.SetInt("currentActivityPoints",currentActivityPoints);       
        if (_currentSize >= 0)
        {
            ResetProgessBar();
        }
    }
}