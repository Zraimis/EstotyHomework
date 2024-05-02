using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Chest : MonoBehaviour
{
    [SerializeField] public UnityEngine.UI.Image chestImage;
    [SerializeField] public GameObject chestClickArea;
    [HideInInspector] public ChestSpawner chestSpawner;
    public int minMoney;
    public int maxMoney;
    public int activityPointsToGet;   
    int random;
    public void Start()
    {
        random = Random.Range(minMoney, maxMoney);
    }    
    public void ChestClick()
    {
        Bank.Instance.AddMoneyFromChest(random);
        Destroy(gameObject);
        chestSpawner.SpawnChest();
        
    }
    public void ChestUnlock()
    {
        chestClickArea.SetActive(true);
        chestImage.color = new Color(chestImage.color.r, chestImage.color.g, chestImage.color.b, 1f);      
    }
}
