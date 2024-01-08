using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillList : MonoBehaviour
{
    [SerializeField] GameObject arrowNoGra;
    [SerializeField] GameObject unit;

    public void SpeedUp_00()
    {

    }

    public void HolizonArrow()
    {
        Instantiate(arrowNoGra, unit.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HolizonArrow();
        }
    }
}
