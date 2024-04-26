using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestOnClick : MonoBehaviour
{
    public Bank bank;
    int random;
    public void Start()
    {
         random = Random.Range(1, 69);
    }    
    public void ChestClick()
    {
        Debug.Log("dsa");
        bank.AddMoneyFromChest(random);
    }
}
