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


    public void Equip(int manager)
    {
        switch (manager)
        {
            case 0:
                def += 5;
                break;

            case 1:
                def += 15;
                break;

            case 2:
                atack = 10 + (int)Math.Round(0.1 * money);
                break;

            case 3:
                atack += 20;
                speed -= 10;
                break;
        }
    }

    //‘•”õ•i‚ğØ‚è‘Ö‚¦‚é‚É‚»‚ê‚Ü‚Å‚Ì‘•”õ•i‚ÌŒø‰Ê‚ğ’ Á‚µ‚É‚·‚é
    public void ResetStatus()
    {
        int atack = 0;
        int speed = 0;
        int def = 0;
        int money = 100;
    }
}
