using EstotyHomework.Configs;
using EstotyHomework.Items;
using EstotyHomework.Managers;
using EstotyHomework.DailyActivitiesComponents;
using System.Collections.Generic;
using UnityEngine;

namespace EstotyHomework.SpawnScripts
{
    public class SpawnCards : MonoBehaviour
    {
        public static SpawnCards Instance;
        public Chest chest;
        public int currentSlot;
        [SerializeField]
        private Card spawnCard;
        [SerializeField]
        private CardConfig[] cardConfigContainer;
        private int _amountOfCardsOnScene = 2;
        private int _randomNumber;
        private int _amountOfCardsToSpawn;
        private readonly List<int> _usedNumbers = new List<int>();
        private CardConfig _randomCard;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        private void RandomNumber()
        {
            _randomNumber = Random.Range(0, cardConfigContainer.Length);
        }

        private void SpawnCardsOnSlots()
        {
            for ( currentSlot = 0; currentSlot <= _amountOfCardsToSpawn; currentSlot++)
            {
                RandomNumber();
                while (_usedNumbers.Contains(_randomNumber))
                {
                    RandomNumber();
                }

                _usedNumbers.Add(_randomNumber);
                _randomCard = cardConfigContainer[_randomNumber];
                Card card = ObjectPoolingManager.Instance.GetPooledObject();
                card.transform.SetParent(transform.GetChild(currentSlot), false);
                card.chest = chest;
                card.UpdateCardData(_randomCard);
                if (_usedNumbers.Count >= 3)
                {
                    _usedNumbers.Clear();
                }
            }
            _amountOfCardsOnScene += _amountOfCardsToSpawn + 1;
            _amountOfCardsToSpawn = 3 - _amountOfCardsOnScene;
        }

        public void ResetCards()
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (GameObject target in gameObjects)
            {
                target.SetActive(false); ;
            }
            _amountOfCardsToSpawn = 2;
            GridManager.Instance.ResetGridManager();
            SpawnCardsOnSlots();
        }
    }
}