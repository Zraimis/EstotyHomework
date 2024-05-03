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
    [HideInInspector] public int currentActivityPoints;
    public Image progressBar;
    public TMP_Text currentActivityPointsText;   
    private float increaseProcent;
    private float increase;
    private float currentSize = -450;
    private float ap;
    
    public void Start()
    {
        currentSize = PlayerPrefs.GetFloat("currentSize");
        currentActivityPointsText.text = PlayerPrefs.GetString("currentActivityPoints");
        progressBar.rectTransform.offsetMax = new Vector2(currentSize, -5);
    }
    public void ResetProgessBar()
    {      
        currentActivityPoints = 0;
        currentActivityPointsText.text = currentActivityPoints.ToString();
        currentSize = -450;       
        progressBar.rectTransform.offsetMax = new Vector2(currentSize, -5);
        PlayerPrefs.SetFloat("currentSize",currentSize);
    }

    public void UpdateProgressBar(Chest chest)
    {
        increaseProcent =  ap / chest.activityPointsToGet;
        increase = 450 * increaseProcent;       
        progressBar.rectTransform.offsetMax = new Vector2(currentSize + increase, -5);
        currentSize = currentSize + increase;

        if (currentSize >= 0f)
        {
            ResetProgessBar();
            chest.ChestUnlock();
        }
        PlayerPrefs.SetFloat("currentSize", currentSize);
    }

    public void changeTextOnClick(int activityPoints)
    {
        ap = activityPoints;
        currentActivityPointsText.text = (currentActivityPoints + activityPoints).ToString();
        currentActivityPoints += activityPoints;
        PlayerPrefs.SetString("currentActivityPoints",currentActivityPoints.ToString());       
        if (currentSize >= 0)
        {
            ResetProgessBar();
        }
    }
}