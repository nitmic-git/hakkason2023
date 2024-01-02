using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class card : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Vector3 firstPos;
    [SerializeField] Vector3 offset;
    [SerializeField] float duration;
    [SerializeField] Canvas canvas;
    [SerializeField] Vector3 scale;

    private void Start()
    {
        firstPos = transform.position;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
        transform.SetAsLastSibling();
        transform.DOMove(firstPos + offset, duration).SetEase(Ease.OutCirc);
        transform.DOScale(scale, duration).SetEase(Ease.OutCirc);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOMove(firstPos, duration).SetEase(Ease.OutCirc);
        transform.DOScale(new Vector3(6,6,6), duration).SetEase(Ease.OutCirc);
    }
}
