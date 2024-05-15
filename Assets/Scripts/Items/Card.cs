using System;
using EstotyHomework.Configs;
using EstotyHomework.Managers;
using EstotyHomework.DailyActivitiesComponents;
using EstotyHomework.SpawnScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EstotyHomework.Items
{
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
        

        public void UpdateCardData(CardConfig cardData)
        {
            logo.sprite = cardData.LogoSprite;
            activityPoints = cardData.ActivityPoints;
            currentAmount = cardData.CurrentAmount;
            maxAmount = cardData.MaxAmount;
            cardTitle.text = cardData.CardTitle;
            isClaimable = cardData.IsClaimable;
            id = SpawnCards.Instance.currentSlot;
            progressText.text = $"{currentAmount}/{maxAmount}";
            gameObject.SetActive(true);
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
                currentAmount += 5;
                if (currentAmount >= maxAmount)
                {
                    ChangeCardToClaimableState();
                }
                else
                {
                    progressText.text = $"{currentAmount}/{maxAmount}";

                }
            }
            else
            {
                ProgressBar.Instance.UpdateProgressBar(chest,activityPoints);
                GridManager.Instance.UpdateGrid(id);
                ObjectPoolingManager.Instance.ResetPoolingCard();
                gameObject.SetActive(false);
            }
        }
    }
}