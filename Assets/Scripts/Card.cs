using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [HideInInspector] public Chest chest;
    [HideInInspector] public Image progressBar;
    [SerializeField] public TMP_Text progressText;
    [SerializeField] public GameObject glowBorder;
    [SerializeField] private Sprite newBackgroundSprite;
    [SerializeField] public Image background;
    [SerializeField] public Image amountPanel;
    [SerializeField] private Sprite newAmountPanelSprite;
    [SerializeField] public Image logo;
    [SerializeField] public TMP_Text cardTitle;
    
    public int activityPoints;
    public bool isClaimable;
    public int currentAmount;
    public int maxAmount;
    public int id;
    private void Update()
    {
        if (!isClaimable)
        {
            if (currentAmount >= maxAmount)
            {
                isClaimable = true;
                progressText.text = "CLAIM";
                progressText.fontSize = 66;
                progressText.color = new Color(0.75f, 0.35f, 0.015f);
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
            ProgressBar.Instance.changeTextOnClick(activityPoints);
            ProgressBar.Instance.UpdateProgressBar(chest);                     
            GridManager.Instance.UpdateGrid(id);
            ObjectPool.Instance.ResetPoolingCard();
            gameObject.SetActive(false);
            
        }          
    }
}