using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCam : MonoBehaviour
{
    [SerializeField] GameObject unit;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - unit.transform.position;
    }

    private void Update()
    {
        transform.position = unit.transform.position + offset;
    }
}
