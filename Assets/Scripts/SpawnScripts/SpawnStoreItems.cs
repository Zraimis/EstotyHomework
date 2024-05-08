using UnityEngine;

public class SpawnStore : MonoBehaviour
{
    [SerializeField] private StoreItem spawnObject;
    [SerializeField] private ShopConfig[] shopConfigContainer;
    public void Start()
    {
        for (int i = 0; i <= shopConfigContainer.Length-1; i++)
        {
            StoreItem storeItem = Instantiate(spawnObject);
            storeItem.transform.SetParent(transform, false);             
            storeItem.moneyToGainFromPurchase.text = (shopConfigContainer[i].FirstBuyAmount).ToString();
            if (shopConfigContainer[i].FirstBuyAmount.ToString().Length == 3)
            {
                storeItem.moneyToGainFromPurchase.fontSize = 50;
            }            
            storeItem.OldAmountText.text = (shopConfigContainer[i].DefaultBuyAmount).ToString();
            storeItem.BuyCost.text = $"{shopConfigContainer[i].BuyCost}$";
            storeItem.DiscountAmount.text = $"+{shopConfigContainer[i].Discount}%";
            storeItem.MoneyIcon.sprite = shopConfigContainer[i].MoneyIcon;
        }
    }
}