using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [HideInInspector] public ChestSpawner chestSpawner;
    [SerializeField] public Image chestImage;
    [SerializeField] public GameObject chestClickArea;
    
    public int minMoney;
    public int maxMoney;
    public int activityPointsToGet;   
    private int random;
    public int id;
    public void Start()
    {
        random = Random.Range(minMoney, maxMoney);
    } 
   
    public void ChestClick()
    {
        Bank.Instance.AddMoneyFromChest(random);
        Destroy(gameObject);
        chestSpawner.SpawnChest();
        ProgressBar.Instance.ResetProgessBar();
        
    }

    public void ChestUnlock()
    {
        chestClickArea.SetActive(true);
        chestImage.color = new Color(chestImage.color.r, chestImage.color.g, chestImage.color.b, 1f);
    }
}