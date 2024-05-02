using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private Chest spawnObject;
    [SerializeField] private ChestConfig[] chestConfigContainer;
    [SerializeField] private WatchAdForChest adForChest;
    [SerializeField] private Card card;
    private int randomNumber;
    private ChestConfig randomChest;
    private void Start()
    {
        SpawnChest();
    }
    private void RandomNumber()
    {
        randomNumber = Random.Range(0, chestConfigContainer.Length);
    }
    public void SpawnChest()
    {
        RandomNumber();
        randomChest = chestConfigContainer[randomNumber];
        Chest chest = Instantiate(spawnObject);
        chest.transform.SetParent(transform, false);
        chest.minMoney = randomChest.minMoney;
        chest.maxMoney = randomChest.maxMoney;
        chest.chestImage.color = new Color(randomChest.color.r, randomChest.color.g, randomChest.color.b, 0.65f);
        chest.activityPointsToGet = randomChest.activityPointsToGet;
        chest.chestSpawner = this;
        chest.chestClickArea.SetActive(false);
        adForChest.chest = chest;
        card.chest = chest;
    }
}
