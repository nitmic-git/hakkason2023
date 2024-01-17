using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillList_hiisu : MonoBehaviour
{
    [SerializeField] GameObject arrowNoGra;
    [SerializeField] GameObject unit;
    [SerializeField] GameObject ArrowStorm;
    [SerializeField] GameObject fireAxis;
    [SerializeField] float fireRotateTime;
    [SerializeField] GameObject Spear;
    [SerializeField] GameObject Bomb;

    //バフの構造体
    private class Buff{
        public int PlayerSpeed;
        public int PlayerAttack;
        public int PlayerDef;
        public int EnemySpeed;
        public int EnemyAttack;
        public int EnemyDef;

        public Buff(int playerSpeed, int playerAttack, int playerDef, int enemySpeed, int enemyAttack, int enemyDef){
            PlayerSpeed = playerSpeed;
            PlayerAttack = playerAttack;
            PlayerDef = playerDef;
            EnemySpeed = enemySpeed;
            EnemyAttack = enemyAttack;
            EnemyDef = enemyDef;
        }
    }

    private static List<Buff> BuffInfo = new List<Buff>()
    {
        new Buff(3, 0, 0, 0, 0, 0), //SpeedUp_00
        new Buff(0, 0, 0, 0, 0, 0), //ArrowStorm_01
        new Buff(0, 0, 0, 0, 0, 0), //fireRotate_02
        new Buff(0, 5, 0, 2, 2, 2), //doubleEdgedSword_03
        new Buff(0, 0, 0, 0, 0, 0), //invincible_04
        new Buff(0, 0, 0, 0, 0, 0), //Spear_05
        new Buff(0, 0, 0, 0, 0, 0), //Bomb_06
    };

    private void ApplyBuff(int id, bool enable)
    {
        if(enable){
            GameMane.playerSpeed += BuffInfo[id].PlayerSpeed;
            GameMane.playerAttack += BuffInfo[id].PlayerAttack;
            GameMane.playerDef += BuffInfo[id].PlayerDef;
            // エネミーのバフ(未実装)
        }else{
            GameMane.playerSpeed -= BuffInfo[id].PlayerSpeed;
            GameMane.playerAttack -= BuffInfo[id].PlayerAttack;
            GameMane.playerDef -= BuffInfo[id].PlayerDef;
            // エネミーのバフ(未実装)
        }
    }

    public void SpeedUp_00()
    {
        //StartCoroutine(activeSkill(演出, 秒数));
        StartCoroutine(activeBuff(0, 3.0f));
    }

    public void ArrowStorm_01()
    {
        Instantiate(ArrowStorm, unit.transform.position + new Vector3(0.3f, 0, 0), Quaternion.Euler(0, 0, 30f));
        Instantiate(ArrowStorm, unit.transform.position + new Vector3(0.2f, 0, 0), Quaternion.Euler(0, 0, 35f));
        Instantiate(ArrowStorm, unit.transform.position + new Vector3(0.1f, 0, 0), Quaternion.Euler(0, 0, 40f));
        Instantiate(ArrowStorm, unit.transform.position + new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 45f));
        Instantiate(ArrowStorm, unit.transform.position + new Vector3(-0.1f, 0, 0), Quaternion.Euler(0, 0, 50f));
        Instantiate(ArrowStorm, unit.transform.position + new Vector3(-0.2f, 0, 0), Quaternion.Euler(0, 0, 55f));
        Instantiate(ArrowStorm, unit.transform.position + new Vector3(-0.3f, 0, 0), Quaternion.Euler(0, 0, 60f));
    }

    public void fireRotate_02()
    {
        StartCoroutine(activeSkill(fireAxis, fireRotateTime));
    }

    public void doubleEdgedSword_03()
    {
        //StartCoroutine(activeSkill(演出, 秒数));
        StartCoroutine(activeBuff(3, 3.0f));
    } 

    public void invincible_04()
    {
        //StartCoroutine(activeSkill(演出,秒数));
        StartCoroutine(activeInvincible(3.0f));
    }

    public void Spear_05()
    {
        Instantiate(Spear);
    }

    public void Bomb_06()
    {
        Instantiate(Bomb, unit.transform.position, Quaternion.identity);
    }

    public void HolizonArrow()
    {
        Instantiate(arrowNoGra, unit.transform.position, Quaternion.identity);
    }

    public IEnumerator activeSkill(GameObject obj, float duration)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(duration);
        obj.SetActive(false);
    }

    public IEnumerator activeInvincible(float duration)
    {
        enemy.DisableDamage(true);
        yield return new WaitForSeconds(duration);
        enemy.DisableDamage(false);
    }

    public IEnumerator activeBuff(int id, float duration)
    {
        ApplyBuff(id, true);
        yield return new WaitForSeconds(duration);
        ApplyBuff(id, false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HolizonArrow();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Bomb_06();
        }
    }
}
