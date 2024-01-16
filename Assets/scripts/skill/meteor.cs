using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class meteor : MonoBehaviour
{
    [SerializeField] float fallSpeed;
    [SerializeField] float delay;
    [SerializeField] float amount;
    Vector3 unitspeed = new(5f, 0f, 0f);
    Vector3 v = new(10f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        unitspeed = unitspeed * fallSpeed;
        transform.DOMove(v+unitspeed, fallSpeed)
            .SetDelay(0f)
            .SetEase(Ease.InCubic);
    }
}
