using DG.Tweening;
using EstotyHomework.PopUps;
using UnityEngine;

namespace EstotyHomework.SpawnScripts
{
    public class StorePopup : MonoBehaviour
    {
        [SerializeField]
        public GameObject spawnLocation;
        [SerializeField]
        private Store storePref;
        public static StorePopup Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        public void OnClickSpawnStore()
        {
            Store store = Instantiate(storePref, spawnLocation.transform, false);
            store.transform.localScale = Vector3.zero;
            store.transform.DOScale(1f, 0.25f);
        }
    }
}