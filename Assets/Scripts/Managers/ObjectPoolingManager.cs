using EstotyHomework.Items;
using System.Collections.Generic;
using UnityEngine;

namespace EstotyHomework.Managers
{
    public class ObjectPoolingManager : MonoBehaviour
    {
        // TODO Does these fields needs to be public?
        public static ObjectPoolingManager Instance { get; private set; }
        public Card objectToPool;
        public int amountToPool;
        [HideInInspector]
        public List<Card> _pooledObjects;
        [SerializeField]
        private Sprite oldBackgroundSprite;
        [SerializeField]
        private Sprite oldAmountPanelSprite;
        private Card poolCard;

        // TODO missing private modifier
        void Awake()
        {
            GridManager.Instance.ClearGridCards();
            Instance = this;
        }
        public void Start()
        {
            _pooledObjects = new List<Card>();
            for (int i = 0; i <= amountToPool; i++)
            {
                // TODO SetParent can be combined with Instantiate
                poolCard = Instantiate(objectToPool);
                poolCard.gameObject.SetActive(false);
                poolCard.transform.SetParent(gameObject.transform, false);
                _pooledObjects.Add(poolCard);
                GridManager.Instance.GetCards(poolCard);
            }
        }
        public Card GetPooledObject()
        {
            for (int i = 0; i <= amountToPool; i++)
            {
                if (!_pooledObjects[i].gameObject.activeInHierarchy)
                {
                    return _pooledObjects[i];
                }
            }
            return null;
        }
        public void ResetPoolingCard()
        {
            foreach (Card foundCard in _pooledObjects)
            {
                foundCard.glowBorder.SetActive(false);
                foundCard.background.sprite = oldBackgroundSprite;
                foundCard.amountPanel.sprite = oldAmountPanelSprite;
                foundCard.progressText.fontSize = 52;
                foundCard.progressText.color = Color.white;
            }
        }
    }
}