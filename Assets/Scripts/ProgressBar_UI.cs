using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar_UI : MonoBehaviour
{
    public static ProgressBar_UI Instance;
    public Image progressBar;
    public TMP_Text currentActivityPointsText;
    public float _currentSize;
    public int currentActivityPoints;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentActivityPoints = PlayerPrefs.GetInt("activityPoints");
        currentActivityPointsText.text = currentActivityPoints.ToString();
        _currentSize = PlayerPrefs.GetFloat("currentSize");
        progressBar.rectTransform.offsetMax = new Vector2(_currentSize, -5);
    }

    void Update()
    {
        currentActivityPointsText.text = currentActivityPoints.ToString();
        progressBar.rectTransform.offsetMax = new Vector2(_currentSize, -5);
        PlayerPrefs.SetFloat("currentSize", _currentSize);
        PlayerPrefs.SetInt("activityPoints", currentActivityPoints);
    }

    public void ResetProgressBarUI()
    {
        _currentSize = -450;
        progressBar.rectTransform.offsetMax = new Vector2(_currentSize, -5);
        PlayerPrefs.SetFloat("currentSize", _currentSize);
    }
}
