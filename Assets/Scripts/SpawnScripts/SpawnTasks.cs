using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTasks : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private ButtonSpawn buttonSpawn;
    [SerializeField] private TMP_Text activityPoointsPanelText;
    [SerializeField] private GameObject chestClickArea;
    [SerializeField] private Image chestImage;
    [SerializeField] private Bank bank;
    private int currentSlot = 0;

    public void SpawnTasksOnSlots()
    {
  
        if (currentSlot <= buttonSpawn.GetSlotCount()) 
        {
            GameObject s = Instantiate(spawnObject);
            s.transform.SetParent(transform.GetChild(currentSlot), false);
            currentSlot++;

            s.GetComponent<TaskManager>().progressBar = progressBar;
            s.GetComponent<TaskManager>().activityPointsPanelText = activityPoointsPanelText;
            s.GetComponent<TaskManager>().chestClickArea = chestClickArea;
            s.GetComponent<TaskManager>().chestImage = chestImage;
        }   
    }
}