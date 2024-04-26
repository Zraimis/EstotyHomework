using TMPro;
using UnityEngine;

public class SpawnStore : MonoBehaviour
{
    [SerializeField] private StoreItem spawnObject;
    [SerializeField] private Bank bank;
    public void Start()
    {
        for (int i = 0; i <= 5; i++)
        {
            StoreItem storeItem = Instantiate(spawnObject);
            storeItem.transform.SetParent(transform, false);
            storeItem.bank = bank;
            
        }
    }
}
    