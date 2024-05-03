using UnityEngine;

public class StorePopup : MonoBehaviour
{
    [SerializeField] private GameObject store;
    public void OnClickShowStore()
    {
        store.SetActive(true);
    }
    public void OnClickDisableStore()
    {
        store.SetActive(false);
    }
}