using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowStorm : MonoBehaviour
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

    public float lifetime = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 一定時間後にオブジェクトを破棄するコルーチンを開始
        StartCoroutine(DestroyAfterLifetime());
    }

    void Update()
    {
        if (rb.velocity != Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        if(transform.position.y < 0) Destroy(gameObject);
    }

    IEnumerator DestroyAfterLifetime()
    {
        // 指定の時間待つ
        yield return new WaitForSeconds(lifetime);

        // 時間経過後にオブジェクトを破棄
        Destroy(gameObject);


    }
}
