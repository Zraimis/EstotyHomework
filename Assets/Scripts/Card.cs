using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int activityPoints;
    public bool isClaimable;
    public int currentAmount;
    public int maxAmount;
    public int id;
    [HideInInspector]
    public Chest chest;
    [HideInInspector]
    public Image progressBar;
    [SerializeField]
    public Image background;
    [SerializeField]
    public Image amountPanel;
    [SerializeField]
    public TMP_Text progressText;
    [SerializeField]
    public GameObject glowBorder;
    [SerializeField]
    public Image logo;
    [SerializeField]
    public TMP_Text cardTitle;
    [SerializeField]
    private Sprite newBackgroundSprite;
    [SerializeField]
    private Sprite newAmountPanelSprite;

    // TODO Update should not be used, call this method only when card should be updated
    private void Update()
    {
        // TODO invert if statement to reduce nesting, see "early return" pattern
        if (!isClaimable)
        {
            if (currentAmount >= maxAmount)
            {
                ChangeCardToClaimableState();
            }
            else
            {
                progressText.text = $"{currentAmount}/{maxAmount}";
            }
        }
    }

    private void ChangeCardToClaimableState()
    {
        isClaimable = true;
        progressText.text = "CLAIM";
        progressText.fontSize = 66;
        progressText.color = new Color(0.75f, 0.35f, 0.015f);
        glowBorder.SetActive(true);
        background.sprite = newBackgroundSprite;
        amountPanel.sprite = newAmountPanelSprite;
    }

    public void OnCardClick()
    {
        if (!isClaimable)
        {
            // TODO convert into compound assignment
            currentAmount = currentAmount + 5;
        }
        else
        {
            ProgressBar.Instance.ChangeTextOnClick(activityPoints);
            ProgressBar.Instance.UpdateProgressBar(chest);
            GridManager.Instance.UpdateGrid(id);
            ObjectPoolingManager.Instance.ResetPoolingCard();
            gameObject.SetActive(false);

        }
    }
}