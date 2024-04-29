using TMPro;
using UnityEngine;

public class OnClickResetAll : MonoBehaviour
{
    [SerializeField] private Bank bank;
    [SerializeField] private SpawnCards spawnCards;
    [SerializeField] private TMP_Text costAmount;
    private int costAmountInt;
    public void OnClickReset()
    {       
        costAmountInt = int.Parse(costAmount.text);
        if (bank.RemoveMoney(costAmountInt))
        {
            spawnCards.ResetCards();
        }
        else
        {
            Debug.Log("Not enough money");
        }       
    }
}
