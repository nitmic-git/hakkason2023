using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class rotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0f, 0f, 300f), rotationSpeed, RotateMode.FastBeyond360).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
