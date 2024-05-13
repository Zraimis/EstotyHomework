using UnityEngine;

public class SpawnStore : MonoBehaviour
{
    [SerializeField] 
    private StoreItem _spawnObject;
    [SerializeField] 
    private ShopConfig[] _shopConfigContainer;
    public void Start()
    {
        for (int i = 0; i <= _shopConfigContainer.Length-1; i++)
        {
            StoreItem storeItem = Instantiate(_spawnObject);
            storeItem.transform.SetParent(transform, false);             
            storeItem.moneyToGainFromPurchase.text = (_shopConfigContainer[i].FirstBuyAmount).ToString();
            if (_shopConfigContainer[i].FirstBuyAmount.ToString().Length == 3)
            {
                storeItem.moneyToGainFromPurchase.fontSize = 50;
            }            
            storeItem.OldAmountText.text = (_shopConfigContainer[i].DefaultBuyAmount).ToString();
            storeItem.BuyCost.text = $"{_shopConfigContainer[i].BuyCost}$";
            storeItem.DiscountAmount.text = $"+{_shopConfigContainer[i].Discount}%";
            storeItem.MoneyIcon.sprite = _shopConfigContainer[i].MoneyIcon;
        }
    }
}