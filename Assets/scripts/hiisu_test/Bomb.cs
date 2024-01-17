using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb : MonoBehaviour
{
    public float initialSpeed = 15f;
    public float acceleration = 10f;
    public float lifetime = 5f;

    private Rigidbody2D rb;
    private GameObject particle;
    private GameObject bombcollider;
    private bool called = false;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();

        // 初速度を与える
        rb.velocity = new Vector3(initialSpeed * 1.1f, initialSpeed * 0.7f, 0f);

        // 加速度を適用する
        rb.AddForce(transform.right * acceleration, ForceMode2D.Impulse);
        rb.angularVelocity = 360f;

        particle = transform.GetChild(0).gameObject;
        bombcollider = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (transform.position.y < 0.4)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
            transform.GetComponent<SpriteRenderer>().enabled = false;
            particle.SetActive(true);
            bombcollider.SetActive(true);

            //Tweeningパッケージを使用して1秒後にDestroy
            if(!called){
                called = true;
                DOVirtual.DelayedCall(1.0f, () => DestroyObject());
            }
        }
    }

    void DestroyObject(){
        called = false;
        Destroy(gameObject);
    }
}
