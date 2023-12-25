using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageMane : MonoBehaviour
{
    [SerializeField] GameObject back;
    [SerializeField] Camera cam;
    [SerializeField] GameObject tree00;
    [SerializeField] int treeAmount;

    [SerializeField] float treeOffsetY;

    [SerializeField] float scaleMin;
    [SerializeField] float scaleMax;

    public  Vector3[] path; 



    // Start is called before the first frame update
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

        
    }

    // Update is called once per frame
    void Update()
    {
        back.transform.position =new Vector3( cam.transform.position.x,cam.transform.position.y,back.transform.position.z);
    }
}
