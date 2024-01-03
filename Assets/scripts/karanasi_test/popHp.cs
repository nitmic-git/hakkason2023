using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class popHp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject hpPop;

    private void Start()
    {
        hpPop.SetActive(false);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {

        hpPop.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hpPop.SetActive(false);
    }
}
