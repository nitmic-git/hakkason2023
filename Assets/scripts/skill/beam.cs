using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class beam : MonoBehaviour
{
    [SerializeField] float expansionDelay;
    [SerializeField] float beamDuration;

    // Start is called before the first frame update
    void Start()
    {
        var beamSequence = DOTween.Sequence();
        beamSequence.Append(this.transform.DOScale(new Vector3(10f, 0.01f, 0f), 0f));
        beamSequence.Append(this.transform.DOScale(new Vector3(10f, 0.3f, 0f), expansionDelay));
        beamSequence.Play();
        //DOVirtual.DelayedCall(beamDuration, () => DOTween.Kill(this.transform));

        //.SetDelay(beamDuration);
        DOTween.Kill(this.transform);
        Destroy(this.gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
