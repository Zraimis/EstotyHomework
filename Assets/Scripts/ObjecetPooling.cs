using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{ 
    [HideInInspector]public List<Card> _pooledObjects;
    [SerializeField] private Sprite oldBackgroundSprite;
    [SerializeField] private Sprite oldAmountPanelSprite;
    public Card objectToPool;
    public int amountToPool;
    public static ObjectPool Instance;

    void Awake()
    {
        Instance = this;  
    }
    private void Start()
    {
        _pooledObjects = new List<Card>();
        Card tmp;
        for (int i = 0; i <= amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.gameObject.SetActive(false);
            _pooledObjects.Add(tmp);
            GridManager.Instance.GetCards(tmp);
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
      foreach(Card foundCard in  _pooledObjects) 
        { 
        foundCard.glowBorder.SetActive(false);
        foundCard.background.sprite = oldBackgroundSprite;
        foundCard.amountPanel.sprite = oldAmountPanelSprite;
        foundCard.progressText.fontSize = 52;
        foundCard.progressText.color = Color.white;
        }
    }
}