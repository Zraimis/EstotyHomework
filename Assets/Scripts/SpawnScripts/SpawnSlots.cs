using EstotyHomework.Items;
using EstotyHomework.Managers;
using UnityEngine;
// TODO Class name should be noun not verb
namespace EstotyHomework.SpawnScripts
{
    public class SpawnSlots : MonoBehaviour
    {
        [SerializeField]
        private Slot spawnObject;

        private const int SlotCount = 2;

        private void Start()
        {
            for (int i = 0; i <= SlotCount; i++)
            {
                Slot slot = Instantiate(spawnObject, transform, false);
                slot.id = i;
                GridManager.Instance.AddSlot(slot);
            }
        }
    }
}