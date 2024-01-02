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
        else if(buttonName=="Mt")
        {
            if(GameMane.playerMapPos.y==5)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (MapGene.playerPathMt[GameMane.playerMapPos.x, 5,GameMane.playerMapPos.x+ i, 6])
                    {
                        GameMane.playerMapPos = new Vector2Int(GameMane.playerMapPos.x + i, 6);
                    }
                }
                Debug.Log("5");

            }
            else if (GameMane.playerMapPos.y == 6)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (MapGene.playerPathMt[GameMane.playerMapPos.x, 6, GameMane.playerMapPos.x + i, 5])
                    {
                        GameMane.playerMapPos = new Vector2Int(GameMane.playerMapPos.x + i, 5);
                    }
                }
                Debug.Log("6");

            }

            Debug.Log("Mt");
            MapGene.deleteButton();
        }
        Debug.Log("aa");
    }
}
