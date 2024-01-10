using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseSkil : MonoBehaviour
{
    //costでお値段,ShowCostは値札の役割,Skillpanelは購入の背景になるやつ
    int cost;
    public GameObject ShowCost;
    public GameObject SkillPanel;
    bool isSkillshown;
    //それぞれ9個ある
    List<bool> haveSkil = new List<bool>() { false, false, false, false, false, false, false, false, false };
    [SerializeField] int skilNo;

    void Start()
    {
        isSkillshown = true;
        switch (skilNo)
        {
            case 0:
                cost = 10;
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
        }
    }

    //ボタンクリック時にアイテム数加算と値段を大体1.5倍に
    public void OnClick()
    {
        if (haveSkil[skilNo])
        {
            Debug.Log("購入済です");
        }
        else
        {
            Debug.Log(skilNo + "が" + cost + "で購入された");
            haveSkil[skilNo] = true;
            cost = (int)Math.Round(1.5 * cost);
            isSkillshown = false;
        }
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "で購入";
        SkillPanel.SetActive(isSkillshown);
    }
}
