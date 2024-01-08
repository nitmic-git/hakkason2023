using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class popGene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    [SerializeField] GameObject pop;
    private bool condition=true;
    private Vector3 firstPos;
    [SerializeField] float xOffset;
    private Vector3 hidePos;
    [SerializeField] float duration;

    private void Start()
    {
        pop.SetActive(true);
        firstPos = pop.transform.position;
        hidePos = new Vector3(firstPos.x + xOffset, firstPos.y, firstPos.z);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {

        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        condition = !condition;
        if (condition)
        {
            pop.transform.DOMove(firstPos, duration).SetEase(Ease.InOutBack);
        }
        else
        {
            pop.transform.DOMove(hidePos, duration).SetEase(Ease.InOutBack);
        }
    }
}
