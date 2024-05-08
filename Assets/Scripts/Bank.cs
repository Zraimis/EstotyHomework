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

    [HideInInspector] public TMP_Text moneyToGainFromPurchase;
    [SerializeField] private TMP_Text moneyAmount;

    private string moneyAmountString;
    private string moneyToGainString;
    private int moneyToGainInt;
    private int moneyAmountInt;
    private string moneyIconString;
    private void Start()
    {
        moneyIconString = "<sprite=\"items\" index=12>";
        moneyAmountString = PlayerPrefs.GetString("moneyAmount");  
        moneyAmount.text = $"{moneyAmountString}{moneyIconString}";
    }

    public void GainMoney()
    {
        moneyToGainString = moneyToGainFromPurchase.text;
        moneyToGainInt = int.Parse(moneyAmountString);
        moneyAmountInt = int.Parse(moneyToGainString);

        moneyAmount.text = $"{moneyAmountInt + moneyToGainInt}{moneyIconString}";
        moneyAmountString = (moneyAmountInt + moneyToGainInt).ToString();
        PlayerPrefs.SetString("moneyAmount", moneyAmountString);
    }

    public void AddMoneyFromChest(int random)
    {
        moneyAmountInt = int.Parse(moneyAmountString);
        moneyAmount.text = $"{moneyAmountInt + random}{moneyIconString}";
        moneyAmountString = (moneyAmountInt + random).ToString();
        PlayerPrefs.SetString("moneyAmount", moneyAmountString);
    }

    public bool RemoveMoney(int amount)
    {
        moneyAmountInt = int.Parse(moneyAmountString);
        if(amount <= moneyAmountInt) 
        {
            moneyAmount.text = $"{moneyAmountInt - amount}{moneyIconString}";
            moneyAmountString = (moneyAmountInt - amount).ToString();
            PlayerPrefs.SetString("moneyAmount", moneyAmountString);

            return true;
        }
        else
        {       
            return false;
        }
    }
}