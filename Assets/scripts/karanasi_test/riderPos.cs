using UnityEngine;
using DG.Tweening;

public class riderPos : MonoBehaviour
{
    public float upDownDistance = 1f;
    public float upDownDuration = 1f;

    [SerializeField] float rotateDuration;
    [SerializeField] float rotateAmount;

    private void Start()
    {
        // DoTweenの初期化
        DOTween.Init();

        // 上下運動の開始
        StartUpDownMotion();
    }

    private void StartUpDownMotion()
    {
        // 上下運動
        transform.DOMoveY( upDownDistance, upDownDuration).SetRelative()
            .SetEase(Ease.InBounce)  // イーズインアウトのイーシングを使用
            .SetLoops(-1, LoopType.Yoyo);  // ループして反復

        transform.DORotate(new Vector3(0f, 0f,rotateAmount), rotateDuration).SetRelative()
            .SetEase(Ease.OutBounce)
             .SetLoops(-1, LoopType.Yoyo); ;
    }
}
