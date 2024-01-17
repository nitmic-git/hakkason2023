using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseItem : MonoBehaviour
{
    //アイテムを購入して所持数を増やしたり、金額を増やしたりする
    //装備とアイテム購入画面は共通であり、ここで購入画面の表示・非表示(・シーン遷移を)管理する
    //costでお値段,ShowCostは値札の役割,itemNoは管理用にボタン一つ一つに割り当てる数字
    int cost;
    public GameObject ShowCost;
    //それぞれ9個ある
    List<int> itemAmount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] int itemNo;
    public GameObject background;
    bool isBackShown;

    void Start()
    {
        isBackShown = true;
        //case0を終了ボタンに割り当てる
        switch (itemNo)
        {
            case 0:
                cost = 0;
                break;

            case 1:
                cost = 9;
                break;

            case 2:
                cost = 8;
                break;

            case 3:
                cost = 7;
                break;

            case 4:
                cost = 6;
                break;

            case 5:
                cost = 5;
                break;

            case 6:
                cost = 4;
                break;

            case 7:
                cost = 3;
                break;

            case 8:
                cost = 2;
                break;

            case 9:
                cost = 1;
                break;
        }
    }

    //ボタンクリック時にアイテム数加算と値段を大体1.5倍に
    public void OnClick()
    {
        if (itemNo == 0)
        {
            isBackShown = false;
        }
        else
        {
            itemAmount[itemNo - 1]++;
            Debug.Log(itemNo + "が" + cost + "で購入された");
            cost = (int)Math.Round(1.5 * cost);
        }
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "で購入";
        background.SetActive(isBackShown);
        //もしisbackshown=falseならシーン遷移に移るとか...?
    }
}
