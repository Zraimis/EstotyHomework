using UnityEngine;


public class ButtonSpawn  : MonoBehaviour
{
    [SerializeField]
    Slot spawnObject;
    private int slotCount;
    void Awake()
    {      
        slotCount = 2;
        for (int i = 0 ; i <= slotCount; i++) 
        {
            Slot slot = Instantiate(spawnObject);
            slot.transform.SetParent(transform, false);
            slot.id = i;
            GridManager.Instance.GetSlots(slot);
        }       
    }
    public int GetSlotCount()
    {
        return slotCount;
    }
}