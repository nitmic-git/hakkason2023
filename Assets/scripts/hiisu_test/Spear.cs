using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    private GameObject unit;
    private float y;
    private bool waiting;
    private const float MaxYValue = 1.3f;
    private const float WaitingSpeed = 0.0001f;
    private const float MovingSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        y = 0.0f;
        waiting = true;
        unit = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Active(2.0f, 2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (y < MaxYValue)
        {
            y += waiting ? WaitingSpeed : MovingSpeed;
        }
        else
        {
            y = MaxYValue;
        }

        Vector3 tmp = transform.position;
        transform.position = new Vector3(unit.transform.position.x + 7.0f, y, tmp.z);
    }

    public IEnumerator Active(float waitingTime, float duration)
    {
        waiting = true;
        yield return new WaitForSeconds(waitingTime);

        waiting = false;
        GameObject[] child = new GameObject[11];
        for(int i = 0; i < 11; i++){
            child[i] = transform.GetChild(i).gameObject;
            child[i].GetComponent<BoxCollider2D>().enabled = true;
        }

        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
