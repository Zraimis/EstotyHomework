using UnityEngine;
using DG.Tweening;

public class DotTweenButtonAnimation : MonoBehaviour
{
    [SerializeField]
    private float _fadeTime;

    private void Start()
    {
        ItemAnimation();
    }
    private void ItemAnimation()
    {
        int taskAmount = transform.GetSiblingIndex();
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, _fadeTime).SetEase(Ease.OutBounce);
    }
}