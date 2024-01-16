using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsSelecter : MonoBehaviour
{
    //アイテム・装備購入画面で表示するボタン=品物を抽選する
    public GameObject[] Item = new GameObject[30];
    int selecter1;
    int selecter2;
    int selecter3;
    int selecter4;


    void Start()
    {
        for(int i=0; i<=12; i++)
        {
            Item[i].SetActive(false);
            Debug.Log(i + "が非アクティブ化");
        }
        //抽選で4つのボタンが出現します
        selecter1 = Random.Range(0, 3);
        selecter2 = Random.Range(0, 3) + 3;
        selecter3 = Random.Range(0, 4) + 6;
        selecter4 = Random.Range(0, 3) + 10;
        Item[selecter1].SetActive(true);
        Item[selecter2].SetActive(true);
        Item[selecter3].SetActive(true);
        Item[selecter4].SetActive(true);

    }
}