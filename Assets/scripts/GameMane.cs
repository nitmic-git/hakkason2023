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

    //����,HP,�U����,������V,�}�ӂ̐�����
    public static object[,] enemyInfo = new object[,]
    {
        {"�X���C��",10,1,2,"(�X���C���̐���)" },
        {"�X�J���E�H�[�J�[",7,3,3,"���̂��s���s��" },
        {"�_�u���X���C��",20,2,4,"�����͓�{!" },
        {"�g���v���X���C��",30,3,6,"������s(ry" },
        {"�c�q�X���C��",50,10,30,"�l�^�@�����������Ȃ�" },
        {"�X�v����",3,6,5,"�ڐG��1�_���[�W��^����" },
        {"�K�[�f�B",20,2,6,"���������U�R�G,��������" },
        {"�W���x�����K",55,5,55,"������" },
        {"�X�J���i�C�g",25,10,20,"���̂͌�����܂���" }
    };

    //true�Ȃ�ۗL,�������̓��x��(���x���͑����������Ȃ�)
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

    //�X�L���̏�����
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
