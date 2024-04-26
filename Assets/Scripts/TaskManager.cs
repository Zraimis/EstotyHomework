using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
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
    [HideInInspector] public GameObject chestClickArea;
    [HideInInspector] public Image chestImage;

    private int activityPoints = 20; // How much you will gain by completing task
    private int currentActivityPoints = 0; // Current Points
    private int currentAmount = 0; // Current amount achieved of task
    private int maxAmount = 10; // How much needs to be achieved
    private bool isClaimable = false;

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

            progressBar.fillAmount += activityPoints/100f;

            if(progressBar.fillAmount >= 1f)
            {
                chestClickArea.SetActive(true);
                chestImage.color = Color.white;
                currentActivityPoints = 0;
                progressBar.fillAmount = 0f;
            }
            PlayerPrefs.SetInt("currentPoints",currentActivityPoints);
            PlayerPrefs.SetFloat("fillAmount", progressBar.fillAmount);

            Destroy(gameObject);
        }          
    }
}