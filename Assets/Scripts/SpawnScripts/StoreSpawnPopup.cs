using DG.Tweening;
using UnityEngine;

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
        Store store = Instantiate(storePref);
        store.transform.SetParent(spawnLocation.transform, false);
        store.transform.localScale = Vector3.zero;
        store.transform.DOScale(1f, 0.25f);
    }
}