using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseItem : MonoBehaviour
{
    //costでお値段,ShowCostは値札の役割,itemNoは管理用にボタン一つ一つに割り当てる数字
    int cost;
    public GameObject ShowCost;
    //それぞれ9個ある
    List<int> itemAmount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] int itemNo;

    void Start()
    {
        switch (itemNo)
        {
            case 0:
                cost = 10;
                Debug.Log("0が動いた" + cost);
                
                break;

            case 1:
                cost = 9;
                Debug.Log("1が動いた" + cost);
                break;

            case 2:
                cost = 8;
                Debug.Log("2が動いた" + cost);
                break;

            case 3:
                cost = 7;
                Debug.Log("3が動いた" + cost);
                break;

            case 4:
                cost = 6;
                Debug.Log("4が動いた" + cost);
                break;

            case 5:
                cost = 5;
                Debug.Log("5が動いた" + cost);
                break;

            case 6:
                cost = 4;
                Debug.Log("6が動いた" + cost);
                break;

            case 7:
                cost = 3;
                Debug.Log("7が動いた" + cost);
                break;

            case 8:
                cost = 2;
                Debug.Log("8が動いた" + cost);
                break;

            case 9:
                cost = 1;
                Debug.Log("9が動いた" + cost);
                break;
        }
    }

    //ボタンクリック時にアイテム数加算と値段を大体1.5倍に
    public void OnClick()
    {
        itemAmount[itemNo]++;
        Debug.Log(itemNo + "が"+cost+"で購入された");
        cost = (int)Math.Round(1.5 * cost);
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "で購入";
    }
}
