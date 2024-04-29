using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCards : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private Card spawnCard;
    [SerializeField] private ButtonSpawn buttonSpawn;
    [SerializeField] private TMP_Text activityPoointsPanelText;
    [SerializeField] private GameObject chestClickArea;
    [SerializeField] private Image chestImage;
    [SerializeField] private Bank bank;
    public void Start()
    {
        SpawnCardsOnSlots();
    }

    public void SpawnCardsOnSlots()
    {

        for (int currentSlot = 0; currentSlot <= buttonSpawn.GetSlotCount(); currentSlot++)
        {
            Card card = Instantiate(spawnCard);
            card.transform.SetParent(transform.GetChild(currentSlot), false);

            card.progressBar = progressBar;
            card.activityPointsPanelText = activityPoointsPanelText;
            card.chestClickArea = chestClickArea;
            card.chestImage = chestImage;

        }
    }
    public void ResetCards()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject target in gameObjects)
        {
            Destroy(target);
            
        }
        SpawnCardsOnSlots();
    }
}