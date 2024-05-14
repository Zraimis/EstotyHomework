using DG.Tweening;
using EstotyHomework.Items;
using EstotyHomework.DailyActivitiesComponents;
using EstotyHomework.DailyActivitiesButtons;
using EstotyHomework.Configs;
using UnityEngine;

namespace EstotyHomework.SpawnScripts
{
    public class ChestSpawner : MonoBehaviour
    {
        [SerializeField]
        private Chest spawnObject;
        [SerializeField]
        private ChestConfig[] chestConfigContainer;
        [SerializeField]
        private WatchAdForChest adForChest;
        [SerializeField]
        private Card card;
        private Chest _chest;
        private int _randomNumber;
        private ChestConfig _randomChest;

        private void Start()
        {
            SpawnChest(PlayerPrefs.GetInt("chestId"));
        }
        private void RandomNumber()
        {
        // TODO get rid of _randomNubmer field and use method to receive random number
            _randomNumber = Random.Range(0, chestConfigContainer.Length);
        }
        // TODO Whats the difference between SpawnChest methods, consider better naming?
    // TODO Get rid of duplicate code
        public void SpawnChest()
        {
            RandomNumber();
            _randomChest = chestConfigContainer[_randomNumber];
            _chest = Instantiate(spawnObject);
            _chest.id = _randomChest.id;
            _chest.transform.SetParent(transform, false);
            _chest.minMoney = _randomChest.minMoney;
            _chest.maxMoney = _randomChest.maxMoney;
            _chest.chestImage.color = new Color(_randomChest.color.r, _randomChest.color.g, _randomChest.color.b, 0.65f);
            _chest.activityPointsToGet = _randomChest.activityPointsToGet;
            _chest.chestSpawner = this;
            _chest.chestClickArea.SetActive(false);
            adForChest.chest = _chest;
            SpawnCards.Instance.chest = _chest;
            ProgressBar.Instance._activityPointsToGet = _chest.activityPointsToGet;
            SpawnChestAnimation();
            PlayerPrefs.SetInt("chestId", _chest.id);
        }

        private void SpawnChestAnimation()
        {
            _chest.transform.localScale = Vector3.zero;
            _chest.transform.DOScale(1f, 0.25f);
        }

        private void SpawnChest(int id)
        {
            _randomChest = chestConfigContainer[id];
            _chest = Instantiate(spawnObject);
            _chest.transform.SetParent(transform, false);
            _chest.minMoney = _randomChest.minMoney;
            _chest.maxMoney = _randomChest.maxMoney;
            _chest.chestImage.color = new Color(_randomChest.color.r, _randomChest.color.g, _randomChest.color.b, 0.65f);
            _chest.activityPointsToGet = _randomChest.activityPointsToGet;
            _chest.chestSpawner = this;
            _chest.chestClickArea.SetActive(false);
            adForChest.chest = _chest;
            SpawnCards.Instance.chest = _chest;
            ProgressBar.Instance._activityPointsToGet = _chest.activityPointsToGet;
        }
    }
}