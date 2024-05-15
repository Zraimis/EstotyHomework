using EstotyHomework.DailyActivitiesComponents;
using EstotyHomework.Configs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EstotyHomework.SpawnScripts
{
    public class ChestSpawner : MonoBehaviour
    {
        public static ChestSpawner Instance { get; private set; }
        [SerializeField]
        private Chest spawnObject;
        [SerializeField]
        private ChestConfig[] chestConfigContainer;
        private ChestConfig chestData;
        private int lastChestId;
        private int s = 0;
        private Chest chest;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            SpawnChest();
        }

        public void SpawnChest()
        {
            if (s == 0)
            {
                lastChestId = PlayerPrefs.GetInt("chestId");
                chest = Instantiate(spawnObject, transform, false);
                chestData = chestConfigContainer[lastChestId];
                chest.SetUp(chestData);
                PlayerPrefs.SetInt("chestId", chestData.ID);
                s++;
            }
            else
            {
                chest = Instantiate(spawnObject, transform, false);
                chestData = chestConfigContainer[Random.Range(0, chestConfigContainer.Length)];
                chest.SetUp(chestData);
                PlayerPrefs.SetInt("chestId", chestData.ID);
            }
        }
    }
}