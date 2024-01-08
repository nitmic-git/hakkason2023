using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class arrowNogravity : MonoBehaviour
{

    [SerializeField]
    int damage = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                
                damageable.Damage(damage);
                Destroy(gameObject);
            }
            else
            {
                
            }
        }

    }

    public float initialSpeed = 10f;
    public float acceleration = 2f;
    public float lifetime = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 初速度を与える
        rb.velocity = transform.right * initialSpeed;

        // 加速度を適用する
        rb.AddForce(transform.right * acceleration, ForceMode2D.Impulse);

        // 一定時間後にオブジェクトを破棄するコルーチンを開始
        StartCoroutine(DestroyAfterLifetime());
    }

    IEnumerator DestroyAfterLifetime()
    {
        // 指定の時間待つ
        yield return new WaitForSeconds(lifetime);

        // 時間経過後にオブジェクトを破棄
        Destroy(gameObject);


    }
}
