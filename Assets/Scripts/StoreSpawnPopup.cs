using DG.Tweening;
using System;
using UnityEngine;

public class StorePopup : MonoBehaviour
{
    [SerializeField] private Store storePref;
    public void OnClickShowStore()
    {
        Store store = Instantiate(storePref);
        store.transform.SetParent(transform.parent.parent.parent.parent, false);
        store.transform.localScale = Vector3.zero;
        store.transform.DOScale(1f, 0.25f);
    }
}