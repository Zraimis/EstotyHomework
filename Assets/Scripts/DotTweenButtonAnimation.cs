using UnityEngine;
using DG.Tweening;

public class DotTweenButtonAnimation : MonoBehaviour
{
    [SerializeField]
    private float fadeTime = 1f;

    private void Start()
    {
        ItemAnimation();
    }
    public void ItemAnimation()
    {
        int taskAmount = transform.GetSiblingIndex();
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce).SetDelay(1*(taskAmount*0.25f));
    }
}