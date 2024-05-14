using TMPro;
using UnityEngine;

public class Bank_UI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text moneyAmountText;
    private int _moneyAmount;
    // TODO Should be constant
    private string _moneyIconString = "<sprite=\"items\" index=12>";

    private void Update()
    { 
        _moneyAmount = Bank.Instance.ReturnMoneyAmount();
        // TODO Redundant .ToString() call
        moneyAmountText.text = _moneyAmount.ToString() + _moneyIconString;
    }
}
