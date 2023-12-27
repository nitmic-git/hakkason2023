using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class Mane_DandD : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 prevPos;

    public void OnBeginDrag(PointerEventData eventData)
    {
        prevPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log("OnDrag called");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var hit in raycastResults)
        {
            //Debug.Log("Hit object: " + hit.gameObject.name);
            if (hit.gameObject.CompareTag("Droppablefield"))
            {
                transform.position = hit.gameObject.transform.position;
                this.enabled = false;
                Debug.Log("OnDrop called");
            }
        }
    }
}
