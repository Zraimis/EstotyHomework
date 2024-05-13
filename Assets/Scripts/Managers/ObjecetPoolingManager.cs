using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager Instance { get; private set; }
    public Card objectToPool;
    public int amountToPool;
    [HideInInspector] 
    public List<Card> _pooledObjects;
    [SerializeField] 
    private Sprite oldBackgroundSprite;
    [SerializeField] 
    private Sprite oldAmountPanelSprite;
    

    void Awake()
    {
        GridManager.Instance.ClearGridCards();
        Instance = this;  
    }
    public void Start()
    {    
        _pooledObjects = new List<Card>();
        Card tmp;
        for (int i = 0; i <= amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.gameObject.SetActive(false);
            tmp.transform.SetParent(gameObject.transform, false);
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