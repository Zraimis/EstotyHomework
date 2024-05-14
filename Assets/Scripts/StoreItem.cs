using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField]
    public TMP_Text moneyToGainFromPurchase;
    [SerializeField]
    public TMP_Text OldAmountText;
    public TMP_Text BuyCost;
    public TMP_Text DiscountAmount;
    public Image MoneyIcon;
    [SerializeField]
    private GameObject moneyToGainObject;
    [SerializeField]
    private GameObject discountBanner;
    [SerializeField]
    private GameObject oldAmount;
    [SerializeField]
    private GameObject oldAmountPanel;
    private int _conversionResult;

    private void ConvertTextToInt()
    {
        if(int.TryParse(moneyToGainFromPurchase.text ,out _conversionResult))
        {
            Bank.Instance.moneyToGainFromPurchase = _conversionResult;
        }
        else
        {
            Debug.Log("Failed conversion");
        }

    }
    public void OnClickBuy()
    {
        ConvertTextToInt();
        Bank.Instance.AddMoney();
        moneyToGainObject.transform.SetParent(oldAmountPanel.transform);
        if (moneyToGainFromPurchase.text.Length >= 4)
        {
            moneyToGainFromPurchase.fontSize = 45;
            moneyToGainObject.transform.localPosition = new Vector3(30f, 7f, 0f);
        }
        else
        {
            moneyToGainFromPurchase.fontSize = 50;
            moneyToGainObject.transform.localPosition = new Vector3(20f, 7f, 0f);
        }
        moneyToGainFromPurchase.text = OldAmountText.text;
        Destroy(oldAmount);
        Destroy(discountBanner);
    }
}