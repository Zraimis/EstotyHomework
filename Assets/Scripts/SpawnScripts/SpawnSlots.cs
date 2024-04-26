using UnityEngine;
using DG.Tweening;

public class ButtonSpawn  : MonoBehaviour
{
    [SerializeField]
    GameObject spawnObject;
    public int slotCount = 12;
    void Start()
    {
        
        for (int i = 0 ; i <= slotCount; i++) 
        {
            GameObject s = Instantiate(spawnObject);
            s.transform.SetParent(transform, false);  
        }       
    }
    public int GetSlotCount()
    {
        return slotCount;
    }
}