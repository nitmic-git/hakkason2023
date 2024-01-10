using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillList : MonoBehaviour
{
    [SerializeField] GameObject arrowNoGra;
    [SerializeField] GameObject unit;
    [SerializeField] GameObject fireAxis;
    [SerializeField] float fireRotateTime;

    public void SpeedUp_00()
    {

    }

    public void HolizonArrow()
    {
        Instantiate(arrowNoGra, unit.transform.position, Quaternion.identity);
    }

    public void fireRotate_02()
    {
        StartCoroutine(active(fireAxis));
    }

    public IEnumerator active(GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(fireRotateTime);
        obj.SetActive(false);
    }



    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HolizonArrow();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            fireRotate_02();
        }
    }
}
