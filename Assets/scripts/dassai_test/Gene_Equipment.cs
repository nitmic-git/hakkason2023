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
    //ステータス上昇:攻撃、速さ、守備
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

    //装備品を切り替える時にそれまでの装備品の効果を帳消しにする
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


//equiparmor,equipweaponで何を装備しているかを表現し、どっかのスクリプト=>多分アイテム管理？
//でisequipweapon,isequiparmorっていうboolでフラグ立てる。
//武具の購入すると、その武具のIDをequiparmor/weaponに代入、それと同時に、isequipをtrueにする

//装備のIDの内0～20は武器に割り振り、21～40は防具に割り振り