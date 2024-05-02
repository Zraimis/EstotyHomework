using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchAdForChest : MonoBehaviour
{
    [HideInInspector] public Chest chest;
    public void OnClickWatchAd()
    {
        chest.ChestUnlock();
    }
}