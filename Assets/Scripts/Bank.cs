using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyAmount;
    [HideInInspector] public TMP_Text moneyToGainFromPurchase;
    private string moneyAmountString;
    private string moneyToGainString;
    private int moneyToGainInt;
    private int moneyAmountInt;
    private int s;
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

        moneyAmount.text =  (moneyAmountInt + moneyToGainInt).ToString();
        PlayerPrefs.SetString("moneyAmount", moneyAmount.text);
    }
    public void AddMoneyFromChest(int random)
    {
        s = int.Parse(moneyAmount.text);
        moneyAmount.text = (s + random).ToString();
        PlayerPrefs.SetString("moneyAmount", moneyAmount.text);
    }
}