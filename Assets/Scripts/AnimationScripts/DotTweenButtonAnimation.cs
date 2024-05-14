using DG.Tweening;
using UnityEngine;

public class DotTweenButtonAnimation : MonoBehaviour
{
    [SerializeField]
    // TODO naming: Unity serialized fields are considered exceptions and _ MUST be removed
    private float _fadeTime;

    private void Start()
    {
        ItemAnimation();
    }

    private void ItemAnimation()
    {
        // TODO taskAmount is never used  
        int taskAmount = transform.GetSiblingIndex();
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, _fadeTime).SetEase(Ease.OutBounce);
    }
}