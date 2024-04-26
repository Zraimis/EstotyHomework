using TMPro;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyToGainFromPurchase;
    [SerializeField] private GameObject moneyToGainObject;
    [HideInInspector] public Bank bank;
    [SerializeField] private GameObject discountBanner;
    [SerializeField] private GameObject oldAmount;
    [SerializeField] private GameObject oldAmountPanel;
    [SerializeField] private TMP_Text oldAmountText;

    public void OnClickBuy()
    {
        bank.moneyToGainFromPurchase = moneyToGainFromPurchase;
        bank.GainMoney();
        moneyToGainObject.transform.SetParent(oldAmountPanel.transform);
        moneyToGainObject.transform.localPosition = new Vector3(12.5f, 7f, 0f);

        moneyToGainFromPurchase.text = oldAmountText.text;

        Destroy(oldAmount);
        Destroy(discountBanner);
        
    }
}