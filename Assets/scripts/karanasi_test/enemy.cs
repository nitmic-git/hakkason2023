using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour, IDamageable
{

    [SerializeField] int enemyNumber;

    int maxHp;
    int hp;
    int attack;
    int money;

    void Start()
    {
        maxHp = (int)GameMane.enemyInfo[enemyNumber, 1];
        hp = maxHp;
        attack = (int)GameMane.enemyInfo[enemyNumber, 2];
        money = (int)GameMane.enemyInfo[enemyNumber, 3];
    }


    

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            
            
            Damage(GameMane.playerSpeed);
            if(hp>0)
            {
                if(GameMane.playerDef>0)
                { 
                }

                GameMane.playerHp -= attack;
                Damage(GameMane.playerAttack);
            }
            
        }
    }

    public int Hp
    {
        get { return hp; }
        set
        {
            hp = Mathf.Clamp(value, 0, maxHp);

            if (hp <= 0)
            {
                Death();
            }
        }
    }

   

    public void Damage(int value)
    {
        Hp -= value;
    }

    public void Death()
    {
        GameMane.money += money;
        Destroy(gameObject);
    }

}

public interface IDamageable
{

    public void Damage(int value);
    public void Death();

}
