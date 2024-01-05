using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseEquip : MonoBehaviour
{
    //costでお値段,ShowCostは値札の役割,itemNoは管理用にボタン一つ一つに割り当てる数字
    int cost;
    public GameObject ShowCost;
    Gene_Equipment geneequip;
    //それぞれ9個ある
    List<bool> isEquipped = new List<bool>() { false, false, false, false, false, false, false, false, false };
    [SerializeField] int equipNo;

    void Start()
    {
        switch (equipNo)
        {
            case 0:
                cost = 10;
                Debug.Log("equip0が動いた" + cost);
                break;

            case 1:
                cost = 9;
                Debug.Log("equip1が動いた" + cost);
                break;

            case 2:
                cost = 8;
                Debug.Log("equip2が動いた" + cost);
                break;

            case 3:
                cost = 7;
                Debug.Log("equip3が動いた" + cost);
                break;
        }
    }

    //ボタンクリック時にアイテム数加算と値段を大体1.5倍に
    public void OnClick()
    {
        if (isEquipped[equipNo])
        {
            Debug.Log("購入済です");
        }
        else
        {
            geneequip.ResetStatus();
            geneequip.Equip(equipNo);
            Debug.Log(equipNo + "が" + cost + "で購入された");
            cost = (int)Math.Round(1.5 * cost);
        }

        /*
        haveEquip[equipNo] = true;
        Debug.Log(equipNo + "が" + cost + "で購入された");
        cost = (int)Math.Round(1.5 * cost);
        */
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "で購入";
    }
}
