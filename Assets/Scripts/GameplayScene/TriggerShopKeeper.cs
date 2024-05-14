using EstotyHomework.SpawnScripts;
using UnityEngine;

namespace EstotyHomework.GameplayScene
{
    public class TriggerShopKeeper : MonoBehaviour
    {
        [SerializeField]
        private GameObject canvas;
        private void OnTriggerEnter(Collider other)
        {
            canvas.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            canvas.SetActive(false);
        }

        public void OnShopKeeperItemClick()
        {
            StorePopup.Instance.OnClickSpawnStore();
        }
    }
}