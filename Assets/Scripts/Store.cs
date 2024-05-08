using DG.Tweening;
using System;
using UnityEngine;

public class Store : MonoBehaviour
{  
    public void DestroyShop()
    {
        transform.DOScale(0f, 1f);
        Destroy(gameObject);
    }
}
