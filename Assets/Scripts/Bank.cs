using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public static Bank Instance { get; private set; }

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

    [SerializeField] private TMP_Text moneyAmount;
    [HideInInspector] public TMP_Text moneyToGainFromPurchase;
    private string moneyAmountString;
    private string moneyToGainString;
    private int moneyToGainInt;
    private int moneyAmountInt;
    private void Update()
    {
        moneyAmount.text = PlayerPrefs.GetString("moneyAmount");
    }

    public void GainMoney()
    {
        moneyAmountString = moneyAmount.text;
        moneyToGainString = moneyToGainFromPurchase.text;
        moneyToGainInt = int.Parse(moneyAmountString);
        moneyAmountInt = int.Parse(moneyToGainString);

        moneyAmount.text = (moneyAmountInt + moneyToGainInt).ToString();
        PlayerPrefs.SetString("moneyAmount", moneyAmount.text);
    }

    public void AddMoneyFromChest(int random)
    {
        moneyAmountInt = int.Parse(moneyAmount.text);
        moneyAmount.text = (moneyAmountInt + random).ToString();
        PlayerPrefs.SetString("moneyAmount", moneyAmount.text);
    }

    public bool RemoveMoney(int amount)
    {
        moneyAmountInt = int.Parse(moneyAmount.text);
        if(amount <= moneyAmountInt) 
        {
            moneyAmount.text = (moneyAmountInt - amount).ToString();
            PlayerPrefs.SetString("moneyAmount", moneyAmount.text);

            return true;
        }
        else
        {       
            return false;
        }
    }
}