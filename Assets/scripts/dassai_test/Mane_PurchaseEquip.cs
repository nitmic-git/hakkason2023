using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseEquip : MonoBehaviour
{
    //cost�ł��l�i,ShowCost�͒l�D�̖���,itemNo�͊Ǘ��p�Ƀ{�^�����Ɋ��蓖�Ă鐔��
    int cost;
    public GameObject ShowCost;
    [SerializeField] Gene_Equipment geneequip;
    //���ꂼ��9����

    [SerializeField] int equipID;
    List<int> equipAmount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };


    void Start()
    {
        switch (equipID)
        {
            case 0:
                cost = 10;
                Debug.Log("equipwp0��������" + cost);
                break;

            case 1:
                cost = 9;
                Debug.Log("equipwp1��������" + cost);
                break;

            case 2:
                cost = 8;
                Debug.Log("equipwp2��������" + cost);
                break;

            case 3:
                cost = 7;
                Debug.Log("equipwp3��������" + cost);
                break;
        }
    }


    //�{�^���N���b�N���ɃA�C�e�������Z�ƒl�i����1.5�{��
    public void OnClick()
    {
        equipAmount[equipID]++;
        Debug.Log(equipID + "��" + cost + "�ōw�����ꂽ");
        geneequip.equipID = equipID;
        geneequip.equip();
        cost = (int)Math.Round(1.5 * cost);
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "�ōw��";
    }
}
