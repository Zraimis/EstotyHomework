using UnityEngine;

namespace EstotyHomework.UI_Overlay
{
    public class Bank : MonoBehaviour
    {
        public static Bank Instance { get; private set; }
        [HideInInspector]
        public int moneyToGainFromPurchase;
        private int _moneyAmount;
        private int _moneyToGain;

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

        private void Start()
        {
            _moneyAmount = PlayerPrefs.GetInt("moneyAmount");
        }

        public void AddMoney()
        {
            _moneyToGain = moneyToGainFromPurchase;
            _moneyAmount = _moneyAmount + _moneyToGain;
            PlayerPrefs.SetInt("moneyAmount", _moneyAmount);
        }

        public void AddMoneyFromChest(int random)
        {
            _moneyAmount = _moneyAmount + random;
            PlayerPrefs.SetInt("moneyAmount", _moneyAmount);
        }

        public bool RemoveMoney(int amount)
        {
            if (amount <= _moneyAmount)
            {
                _moneyAmount = _moneyAmount - amount;
                PlayerPrefs.SetInt("moneyAmount", _moneyAmount);

                return true;
            }
            else
            {
                return false;
            }
        }

        public int ReturnMoneyAmount()
        {
            return _moneyAmount;
        }
    }
}