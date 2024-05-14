using UnityEngine;

public class SpawnSlots : MonoBehaviour
{
    [SerializeField]
    private Slot spawnObject;
    private int _slotCount = 2;
    void Start()
    {
        for (int i = 0; i <= _slotCount; i++)
        {
            Slot slot = Instantiate(spawnObject);
            slot.transform.SetParent(transform, false);
            slot.id = i;
            GridManager.Instance.GetSlots(slot);
        }
    }
}