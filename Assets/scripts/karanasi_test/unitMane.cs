using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitMane : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3[] path;
    [SerializeField] GameObject unit;
    [SerializeField] GameObject ground;

    private int section=0;
    private Vector3 direction;
    private bool end = false;

    private void Start()
    {
        unit.transform.position = path[0];
    }

    private void Update()
    {

        //groundGene();
        if (path[section].x<=unit.transform.position.x&&section<path.Length-1)
        {
            section++;
            
        }

        if (path[path.Length - 1].x < unit.transform.position.x&&!end)
        {
            end = true;
            Debug.Log("“¹’†I—¹");
        }

        if (!end)
        {
           
            direction = (path[section] - path[section - 1]).normalized;

            unit.transform.position += direction * speed;
        }
       
    }

    public void groundGene()
    {
        SpriteRenderer sp = ground.GetComponent<SpriteRenderer>();
        if(Input.GetMouseButton(0))
        {
            ground.transform.localScale = new Vector3(2, 1, 1);
        }
    }
}
