using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class popGene : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject pop;

    private void Start()
    {
        pop.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {

        pop.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pop.SetActive(false);
    }
}
