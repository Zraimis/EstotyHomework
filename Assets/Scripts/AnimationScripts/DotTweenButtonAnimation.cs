using DG.Tweening;
using UnityEngine;

namespace EstotyHomeWork.AnimationScripts
{

    public class DotTweenButtonAnimation : MonoBehaviour
    { 
    [SerializeField]
    private float fadeTime;

    private void Start()
    {
        ItemAnimation();
    }
    private void ItemAnimation()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
    }
    }
}