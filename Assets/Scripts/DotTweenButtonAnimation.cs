using UnityEngine;
using DG.Tweening;

public class DotTweenButtonAnimation : MonoBehaviour
{
    [SerializeField]
    private float fadeTime;

    private void Start()
    {
        ItemAnimation();
    }
    public void ItemAnimation()
    {
        int taskAmount = transform.GetSiblingIndex();
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
    }
}