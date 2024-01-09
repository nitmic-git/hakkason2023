using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gene_Equipment : MonoBehaviour
{
    int atack=0;
    int speed=0;
    int def = 0;
    int money = 100;
    //�X�e�[�^�X�㏸:�U���A�����A���
    int[] debuffweapon = new int[]{ 0, 0, 0 };
    int[] debuffarmor = new int[]{ 0, 0, 0 };

    public int equipID;

    public void equip() 
    {
        if(equipID<21)
        {
            ResetStatus(true);
            EquipFunction(equipID);
            debuffStatus(true);
        }
        else
        {
            ResetStatus(false);
            EquipFunction(equipID);
            debuffStatus(false);
        }
    }

    public void EquipFunction(int equipID)
    {
        switch (equipID)
        {
            case 0:
                debuffweapon[0] = 5;
                debuffweapon[1] = 0;
                debuffweapon[2] = 0;
                break;

            case 1:
                debuffweapon[0] = 10 + (int)Math.Round(0.1 * money);
                debuffweapon[1] = 0;
                debuffweapon[2] = 0;
                break;

            case 3:
                debuffweapon[0] = 20;
                debuffweapon[1] = -10;
                debuffweapon[2] = 0;
                break;

            case 21:
                debuffarmor[0] = 0;
                debuffarmor[1] = 0;
                debuffarmor[2] = 10;
                break;

            case 22:
                debuffarmor[0] = 0;
                debuffarmor[1] = 0;
                debuffarmor[2] = 30;
                break;
        }
    }

    //�����i��؂�ւ��鎞�ɂ���܂ł̑����i�̌��ʂ𒠏����ɂ���
    public void ResetStatus(bool isweapon)
    {
        if (isweapon)
        {
            atack -= debuffweapon[0];
            speed -= debuffweapon[1];
            def -= debuffweapon[2];
        }
        else
        {
            atack -= debuffarmor[0];
            speed -= debuffarmor[1];
            def -= debuffarmor[2];
        }
    }

    public void debuffStatus(bool isweapon)
    {
        if (isweapon)
        {
            atack += debuffweapon[0];
            speed += debuffweapon[1];
            def += debuffweapon[2];
        }
        else
        {
            atack += debuffarmor[0];
            speed += debuffarmor[1];
            def += debuffarmor[2];
        }
    }
}


//equiparmor,equipweapon�ŉ��𑕔����Ă��邩��\�����A�ǂ����̃X�N���v�g=>�����A�C�e���Ǘ��H
//��isequipweapon,isequiparmor���Ă���bool�Ńt���O���Ă�B
//����̍w������ƁA���̕����ID��equiparmor/weapon�ɑ���A����Ɠ����ɁAisequip��true�ɂ���

//������ID�̓�0�`20�͕���Ɋ���U��A21�`40�͖h��Ɋ���U��