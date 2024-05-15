using EstotyHomework.Items;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace EstotyHomework.Managers
{
    public class ObjectPoolingManager : MonoBehaviour
    {
        // TODO Does these fields needs to be public?
        public static ObjectPoolingManager Instance { get; private set; }
        public Card objectToPool;
        public int amountToPool;
        [FormerlySerializedAs("_pooledObjects")] [HideInInspector]
        public List<Card> pooledObjects;
        [SerializeField]
        private Sprite oldBackgroundSprite;
        [SerializeField]
        private Sprite oldAmountPanelSprite;
        private Card poolCard;
        
        private void Awake()
        {
            GridManager.Instance.ClearGridCards();
            Instance = this;
        }
        public void Start()
        {
            pooledObjects = new List<Card>();
            for (int i = 0; i <= amountToPool; i++)
            {
                // TODO SetParent can be combined with Instantiate
                poolCard = Instantiate(objectToPool, gameObject.transform, false);
                poolCard.gameObject.SetActive(false);
                pooledObjects.Add(poolCard);
                GridManager.Instance.AddCard(poolCard);
            }
        }
        public Card GetPooledObject()
        {
            for (int i = 0; i <= amountToPool; i++)
            {
                if (!pooledObjects[i].gameObject.activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
        public void ResetPoolingCard()
        {
            foreach (Card foundCard in pooledObjects)
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