using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Mane : MonoBehaviour
{

    private GameObject unit;
    private bool oneTime=false;
    private int Hp;
    
    void Start()
    {
        Hp = GameMane.Hp_e1;
        unit = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (unit.transform.position.x+GameMane.range>=transform.position.x&&!oneTime)
        {
            Debug.Log("ÚG");
            oneTime = true;
            Hp -= GameMane.playerSpeed;
            Debug.Log(Hp);
            Debug.Log(GameMane.money);
            if(Hp>=1)
            {
                GameMane.playerHp -= GameMane.attack_e1;
                Hp -= GameMane.playerAttack;
            }
        }

       

        if(Hp<=0)
        {
            GameMane.money += GameMane.score_e1;
            Destroy(gameObject);
        }
    }
}
