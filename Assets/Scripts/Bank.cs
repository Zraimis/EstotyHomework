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

    [HideInInspector] 
    public TMP_Text moneyToGainFromPurchase;
    [SerializeField] 
    private TMP_Text moneyAmount;

    private string _moneyAmountString;
    private string _moneyToGainString;
    private int _moneyToGainInt;
    private int _moneyAmountInt;
    private string _moneyIconString;
    private void Start()
    {
        _moneyIconString = "<sprite=\"items\" index=12>";
        _moneyAmountString = PlayerPrefs.GetString("moneyAmount");  
        moneyAmount.text = $"{_moneyAmountString}{_moneyIconString}";
    }

    public void AddMoney()
    {
        _moneyToGainString = moneyToGainFromPurchase.text;
        _moneyToGainInt = int.Parse(_moneyAmountString);
        _moneyAmountInt = int.Parse(_moneyToGainString);

        moneyAmount.text = $"{_moneyAmountInt + _moneyToGainInt}{_moneyIconString}";
        _moneyAmountString = (_moneyAmountInt + _moneyToGainInt).ToString();
        PlayerPrefs.SetString("moneyAmount", _moneyAmountString);
    }

    public void AddMoneyFromChest(int random)
    {
        _moneyAmountInt = int.Parse(_moneyAmountString);
        moneyAmount.text = $"{_moneyAmountInt + random}{_moneyIconString}";
        _moneyAmountString = (_moneyAmountInt + random).ToString();
        PlayerPrefs.SetString("moneyAmount", _moneyAmountString);
    }

    public bool RemoveMoney(int amount)
    {
        _moneyAmountInt = int.Parse(_moneyAmountString);
        if(amount <= _moneyAmountInt) 
        {
            moneyAmount.text = $"{_moneyAmountInt - amount}{_moneyIconString}";
            _moneyAmountString = (_moneyAmountInt - amount).ToString();
            PlayerPrefs.SetString("moneyAmount", _moneyAmountString);

            return true;
        }
        else
        {       
            return false;
        }
    }
}