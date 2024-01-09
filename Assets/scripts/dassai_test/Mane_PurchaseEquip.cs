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
    [SerializeField] Gene_Equipment geneequip;
    //それぞれ9個ある

    [SerializeField] int equipID;
    List<int> equipAmount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };


    void Start()
    {
        switch (equipID)
        {
            case 0:
                cost = 10;
                Debug.Log("equipwp0が動いた" + cost);
                break;

            case 1:
                cost = 9;
                Debug.Log("equipwp1が動いた" + cost);
                break;

            case 2:
                cost = 8;
                Debug.Log("equipwp2が動いた" + cost);
                break;

            case 3:
                cost = 7;
                Debug.Log("equipwp3が動いた" + cost);
                break;
        }
    }


    //ボタンクリック時にアイテム数加算と値段を大体1.5倍に
    public void OnClick()
    {
        equipAmount[equipID]++;
        Debug.Log(equipID + "が" + cost + "で購入された");
        geneequip.equipID = equipID;
        geneequip.equip();
        cost = (int)Math.Round(1.5 * cost);
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "で購入";
    }
}
