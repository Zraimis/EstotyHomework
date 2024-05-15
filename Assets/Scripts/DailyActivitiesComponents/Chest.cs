using EstotyHomework.Configs;
using EstotyHomework.DailyActivitiesButtons;
using EstotyHomework.SpawnScripts;
using EstotyHomework.UI_Overlay;
using UnityEngine;
using UnityEngine.UI;

namespace EstotyHomework.DailyActivitiesComponents
{
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
        private int random;

        public void SetUp(ChestConfig chestData)
        {
            minMoney = chestData.MinMoney;
            maxMoney = chestData.MaxMoney;
            random = Random.Range(minMoney, maxMoney);
            chestImage.color = new Color(chestData.Color.r, chestData.Color.g, chestData.Color.b, 0.65f);
            activityPointsToGet = chestData.ActivityPointsToGet;
            chestSpawner = ChestSpawner.Instance;
            chestClickArea.SetActive(false);
            WatchAdForChestButton.Instance.chest = this;
            SpawnCards.Instance.chest = this;
            ProgressBar.Instance.ActivityPointsToGet = activityPointsToGet;
            if (PlayerPrefs.GetInt("ChestUnlocked") == 1)
            {
                ChestUnlock();
            }
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
}