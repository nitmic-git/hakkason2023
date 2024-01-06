using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Enemy", menuName = "CreateEnemy")]
public class Enemy : ScriptableObject{

    public String Name; //名前
    public int hp; //HP
    public int power; //攻撃力
    public Sprite sprite; //画像
    public String information; // 情報

    public Enemy(Enemy enemy){
        this.Name = enemy.Name;
        this.hp = enemy.hp;
        this.power = enemy.power;
        this.sprite = enemy.sprite;
        this.information = enemy.information;
    }
}