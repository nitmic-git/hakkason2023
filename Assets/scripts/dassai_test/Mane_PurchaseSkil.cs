using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//スキル購入によるお金の増減、スキル取得フラグの管理をする
//購入/終了ボタンを押すと次のアイテム/装備購入画面に移る
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

    //case10を終了ボタンに割り当て
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
            case 10:
                cost = 0;
                break;
        }
    }

    //ボタンクリック時にアイテム数加算と値段を大体1.5倍に
    public void OnClick()
    {
        if (skilNo == 10)
        {
            Debug.Log("購入フェイズ終了");
            isSkillshown = false;
        }
        if (skilNo != 10)
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
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "で購入";
        SkillPanel.SetActive(isSkillshown);
    }
}
