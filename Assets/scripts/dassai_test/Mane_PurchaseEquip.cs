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
    Gene_Equipment geneequip;
    //���ꂼ��9����
    List<bool> isEquipped = new List<bool>() { false, false, false, false, false, false, false, false, false };
    [SerializeField] int equipNo;

    void Start()
    {
        switch (equipNo)
        {
            case 0:
                cost = 10;
                Debug.Log("equip0��������" + cost);
                break;

            case 1:
                cost = 9;
                Debug.Log("equip1��������" + cost);
                break;

            case 2:
                cost = 8;
                Debug.Log("equip2��������" + cost);
                break;

            case 3:
                cost = 7;
                Debug.Log("equip3��������" + cost);
                break;
        }
    }

    //�{�^���N���b�N���ɃA�C�e�������Z�ƒl�i����1.5�{��
    public void OnClick()
    {
        if (isEquipped[equipNo])
        {
            Debug.Log("�w���ςł�");
        }
        else
        {
            geneequip.ResetStatus();
            geneequip.Equip(equipNo);
            Debug.Log(equipNo + "��" + cost + "�ōw�����ꂽ");
            cost = (int)Math.Round(1.5 * cost);
        }

        /*
        haveEquip[equipNo] = true;
        Debug.Log(equipNo + "��" + cost + "�ōw�����ꂽ");
        cost = (int)Math.Round(1.5 * cost);
        */
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "�ōw��";
    }
}
