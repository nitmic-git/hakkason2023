using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class normalBullet : MonoBehaviour
{

    [SerializeField]
    int damage = 3;

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {

                damageable.Damage(damage);
                
            }
            else
            {

            }
        }

    }

    

    
}
