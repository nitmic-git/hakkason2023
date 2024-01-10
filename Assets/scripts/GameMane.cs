using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMane : MonoBehaviour
{
    public static int money=0;

    public static Vector2Int playerMapPos=new Vector2Int(0,2);

    public static int playerSpeed = 10;
    public static int playerAttack=10;
    public static int playerHp=100;
    public static int playerDef=1;
    public static float range = 1;

    public static int Hp_e1=8;
    public static int attack_e1=3;
    public static int score_e1 = 2;

    //名称,HP,攻撃力,討伐報酬,図鑑の説明文
    public static object[,] enemyInfo = new object[,]
    {
        {"スライム",10,1,2,"(スライムの説明)" },
        {"スカルウォーカー",7,3,3,"胴体が行方不明" },
        {"ダブルスライム",20,2,4,"強さは二倍!" },
        {"トリプルスライム",30,3,6,"強さはs(ry" },
        {"団子スライム",50,10,30,"ネタ　多分実装しない" },
        {"スプリン",3,6,5,"接触時1ダメージを与える" },
        {"ガーディ",20,2,6,"盾もったザコ敵,かたいよ" },
        {"ジャベリンガ",55,5,55,"強いよ" },
        {"スカルナイト",25,10,20,"胴体は見つかりました" }
    };

    //trueなら保有,第二引数はレベル(レベルは多分実装しない)
    public static object[,] hasSkill = new object[,]
    {
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 },
        {false,0 }
    };

    //スキルの所持数
    public static int skillAmount=0;

   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
