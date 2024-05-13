using UnityEngine;

public class WatchAdForChest : MonoBehaviour
{
    [HideInInspector] 
    public Chest chest;
    public void OnClickWatchAd()
    {
        chest.ChestUnlock();
    }
}