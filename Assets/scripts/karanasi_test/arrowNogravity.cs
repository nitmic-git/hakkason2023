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

        // �����x��^����
        rb.velocity = transform.right * initialSpeed;

        // �����x��K�p����
        rb.AddForce(transform.right * acceleration, ForceMode2D.Impulse);

        // ��莞�Ԍ�ɃI�u�W�F�N�g��j������R���[�`�����J�n
        StartCoroutine(DestroyAfterLifetime());
    }

    IEnumerator DestroyAfterLifetime()
    {
        // �w��̎��ԑ҂�
        yield return new WaitForSeconds(lifetime);

        // ���Ԍo�ߌ�ɃI�u�W�F�N�g��j��
        Destroy(gameObject);


    }
}
