using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mapButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        string buttonName = eventData.pointerPress.name;
        if (buttonName == "button1")
        {
            GameMane.playerMapPos = new Vector2Int(GameMane.playerMapPos.x + 1,MapGene.nextYPos[GameMane.playerMapPos.x, GameMane.playerMapPos.y, 0]);
            Debug.Log("1");
            MapGene.deleteButton();
        }
        else if (buttonName == "button2")
        {
            GameMane.playerMapPos = new Vector2Int(GameMane.playerMapPos.x + 1, MapGene.nextYPos[GameMane.playerMapPos.x, GameMane.playerMapPos.y, 1]);
            Debug.Log("2");
            MapGene.deleteButton();
        }
        else if (buttonName == "button3")
        {
            GameMane.playerMapPos = new Vector2Int(GameMane.playerMapPos.x + 1, MapGene.nextYPos[GameMane.playerMapPos.x, GameMane.playerMapPos.y, 2]);
            Debug.Log("3");
            MapGene.deleteButton();
        }
        Debug.Log("aa");
    }
}
