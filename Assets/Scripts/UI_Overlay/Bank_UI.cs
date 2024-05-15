using TMPro;
using UnityEngine;

namespace EstotyHomework.UI_Overlay
{
    public class Bank_UI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text moneyAmountText;
        private int _moneyAmount;
        private const string MoneyIconString = "<sprite=\"items\" index=12>";

        private void Update()
        {
            _moneyAmount = Bank.Instance.ReturnMoneyAmount();
            moneyAmountText.text = _moneyAmount + MoneyIconString;
        }
    }
}