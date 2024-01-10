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
        // DoTween�̏�����
        DOTween.Init();

        // �㉺�^���̊J�n
        StartUpDownMotion();
    }

    private void StartUpDownMotion()
    {
        // �㉺�^��
        transform.DOMoveY( upDownDistance, upDownDuration).SetRelative()
            .SetEase(Ease.InBounce)  // �C�[�Y�C���A�E�g�̃C�[�V���O���g�p
            .SetLoops(-1, LoopType.Yoyo);  // ���[�v���Ĕ���

        transform.DORotate(new Vector3(0f, 0f,rotateAmount), rotateDuration).SetRelative()
            .SetEase(Ease.OutBounce)
             .SetLoops(-1, LoopType.Yoyo); ;
    }
}
