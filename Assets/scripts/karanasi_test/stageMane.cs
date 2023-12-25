using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageMane : MonoBehaviour
{
    [SerializeField] GameObject back;
    [SerializeField] Camera cam;
    [SerializeField] GameObject tree00;
    [SerializeField] int treeAmount;

    [SerializeField] float treeOffsetY;

    [SerializeField] float scaleMin;
    [SerializeField] float scaleMax;

    [SerializeField] GameObject enemy1;

    public  Vector3[] path;

    [SerializeField] int[] enemyAmounts;
    [SerializeField] float enemy1OffsetY;

    [SerializeField] Text[] paraText;

    
    


    void Start()
    {
        Vector3[] treePos=new Vector3[treeAmount];
        float min = path[0].x;
        float max = path[path.Length-1].x;

        
        for (int i = 0; i < treeAmount; i++)
        {
            treePos[i].x = Random.Range(min, max);
            for (int j = 1; j < path.Length; j++)
            {
                if(treePos[i].x<path[j].x)
                {
                    float lenX = path[j].x - path[j - 1].x;
                    float lenY =( path[j].y - path[j - 1].y);
                    treePos[i].y = path[j - 1].y + (treePos[i].x - path[j-1].x) / lenX * lenY+treeOffsetY;
                    break;
                }
            }
            GameObject tree= Instantiate(tree00, treePos[i], Quaternion.identity);
            float r = Random.Range(scaleMin, scaleMax)
;            tree.transform.localScale =new Vector3 (r, r, 1);
        }

        spawn();
    }

    
    void Update()
    {
        back.transform.position =new Vector3( cam.transform.position.x,cam.transform.position.y,back.transform.position.z);

       
    }

    public void UIMane()
    {
        paraText[0].text = "Money:" + GameMane.money;
        paraText[1].text = "Attack:" + GameMane.playerAttack;
        paraText[2].text = "Defense:" + GameMane.playerDef;
        paraText[3].text = "Speed::" + GameMane.playerSpeed;

    }

    

    
    public void spawn()
    {
        for (int i = 0; i <enemyAmounts.Length; i++)
        {
            for (int j = 0; j < enemyAmounts[i]; j++)
            {
                float lenthX = path[path.Length - 1].x - path[0].x;
                float min = (float)(i + 0.5) * lenthX / 10;
                float max = (float)(i + 1.5) * lenthX / 10;
                float posX = Random.Range(min, max);
                float posY=0;

                for (int k = 1; k < path.Length; k++)
                {
                    if (posX < path[k].x)
                    {
                        float lenX = path[k].x - path[k - 1].x;
                        float lenY = (path[k].y - path[k - 1].y);
                        posY = path[k - 1].y + (posX - path[k - 1].x) / lenX * lenY +enemy1OffsetY;
                        break;
                    }
                }

                Instantiate(enemy1, new Vector3(posX, posY, 0), Quaternion.identity);
            }
            
        }
    }

}
