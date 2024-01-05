using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class Mane_DandD : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler
{
    private Vector2 prevPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        prevPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var hit in raycastResults)
        {
            if (hit.gameObject.CompareTag("Droppablefield"))
            {
                transform.position = hit.gameObject.transform.position;
                this.enabled = false;
            }
            else
            {
                transform.position = prevPos;
                return;
            }
        }
    }
}
