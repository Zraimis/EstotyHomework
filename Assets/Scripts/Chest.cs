using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [HideInInspector]
    public ChestSpawner chestSpawner;
    [SerializeField]
    public Image chestImage;
    [SerializeField]
    public GameObject chestClickArea;
    public int minMoney;
    public int maxMoney;
    public int activityPointsToGet;
    public int id;
    private int random;

    public void Start()
    {
        if (PlayerPrefs.GetInt("ChestUnlocked") == 1)
        {
            ChestUnlock();
        }
        random = Random.Range(minMoney, maxMoney);
    }

    public void ChestClick()
    {
        Bank.Instance.AddMoneyFromChest(random);
        ProgressBar.Instance.ResetProgessBar();
        PlayerPrefs.SetInt("ChestUnlocked", 0);
        Destroy(gameObject);
        chestSpawner.SpawnChest();
    }

    public void ChestUnlock()
    {
        chestClickArea.SetActive(true);
        chestImage.color = new Color(chestImage.color.r, chestImage.color.g, chestImage.color.b, 1f);
        PlayerPrefs.SetInt("ChestUnlocked", 1);
    }
}