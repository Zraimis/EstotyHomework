using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [HideInInspector] public Image progressBar;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private GameObject glowBorder;
    [SerializeField] private Sprite newBackgroundSprite;
    [SerializeField] private Image background;
    [SerializeField] private Image amountPanel;
    [SerializeField] private Sprite newAmountPanelSprite;
    [SerializeField] private TMP_Text activityPointsText;
    [HideInInspector] public TMP_Text activityPointsPanelText;
    [SerializeField] public Image logo;
    [SerializeField] public TMP_Text cardTitle;
    [HideInInspector] public Chest chest;

    public int activityPoints;
    private int currentActivityPoints;
    public bool isClaimable;
    public int currentAmount;
    public int maxAmount;
    public int id;
    private void Update()
    {
        currentActivityPoints = PlayerPrefs.GetInt("currentPoints");
        progressBar.fillAmount = PlayerPrefs.GetFloat("fillAmount");
        activityPointsPanelText.text = currentActivityPoints.ToString();
        activityPointsText.text = activityPoints.ToString();
        if (!isClaimable)
        {
            if (currentAmount >= maxAmount)
            {
                isClaimable = true;
                progressText.text = "CLAIM";
                progressText.color = new Color(2.51f, 0.6f, 0.01f);
                glowBorder.SetActive(true);
                background.sprite = newBackgroundSprite;
                amountPanel.sprite = newAmountPanelSprite;
            }
            else
            {
                progressText.text = $"{currentAmount}/{maxAmount}";
            }
        }
    }

    public void OnClaimClick()
    {
        if (!isClaimable) 
        {
            currentAmount = currentAmount + 5;      
        }
        else
        {           
            activityPointsPanelText.text = (currentActivityPoints + activityPoints).ToString();
            currentActivityPoints += activityPoints;

            UpdateProgressBar();

            if(progressBar.fillAmount >= 1f)
            {
                ResetProgessBar();
                chest.ChestUnlock();
            }
            
            PlayerPrefs.SetInt("currentPoints",currentActivityPoints);
            PlayerPrefs.SetFloat("fillAmount", progressBar.fillAmount);

            GridManager.Instance.UpdateGrid(id);
            Destroy(gameObject);
        }          
    }
    public void ResetProgessBar()
    {
        currentActivityPoints = 0;
        progressBar.fillAmount = 0f;
    }
    public void UpdateProgressBar()
    {
        float fillAmount = (float.Parse(currentActivityPoints.ToString()) / float.Parse(chest.activityPointsToGet.ToString()));
        progressBar.fillAmount = fillAmount;
    }
}