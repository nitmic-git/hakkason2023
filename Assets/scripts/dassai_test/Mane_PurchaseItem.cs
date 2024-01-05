using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseItem : MonoBehaviour
{
    //cost�ł��l�i,ShowCost�͒l�D�̖���,itemNo�͊Ǘ��p�Ƀ{�^�����Ɋ��蓖�Ă鐔��
    int cost;
    public GameObject ShowCost;
    //���ꂼ��9����
    List<int> itemAmount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] int itemNo;

    void Start()
    {
        switch (itemNo)
        {
            case 0:
                cost = 10;
                Debug.Log("0��������" + cost);
                
                break;

            case 1:
                cost = 9;
                Debug.Log("1��������" + cost);
                break;

            case 2:
                cost = 8;
                Debug.Log("2��������" + cost);
                break;

            case 3:
                cost = 7;
                Debug.Log("3��������" + cost);
                break;

            case 4:
                cost = 6;
                Debug.Log("4��������" + cost);
                break;

            case 5:
                cost = 5;
                Debug.Log("5��������" + cost);
                break;

            case 6:
                cost = 4;
                Debug.Log("6��������" + cost);
                break;

            case 7:
                cost = 3;
                Debug.Log("7��������" + cost);
                break;

            case 8:
                cost = 2;
                Debug.Log("8��������" + cost);
                break;

            case 9:
                cost = 1;
                Debug.Log("9��������" + cost);
                break;
        }
    }

    //�{�^���N���b�N���ɃA�C�e�������Z�ƒl�i����1.5�{��
    public void OnClick()
    {
        itemAmount[itemNo]++;
        Debug.Log(itemNo + "��"+cost+"�ōw�����ꂽ");
        cost = (int)Math.Round(1.5 * cost);
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "�ōw��";
    }
}
