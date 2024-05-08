using UnityEngine;

public class StorePopup : MonoBehaviour
{
    [SerializeField] private Store storePref;
    public void OnClickShowStore()
    {
        Store store = Instantiate(storePref);
        store.transform.SetParent(transform.parent.parent.parent.parent, false);  
    }
}