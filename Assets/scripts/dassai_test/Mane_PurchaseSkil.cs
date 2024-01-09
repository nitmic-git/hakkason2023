using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseSkil : MonoBehaviour
{
    //cost�ł��l�i,ShowCost�͒l�D�̖���,itemNo�͊Ǘ��p�Ƀ{�^�����Ɋ��蓖�Ă鐔��
    int cost;
    public GameObject ShowCost;
    public GameObject SkillPanel;
    bool isSkillFinished;
    //���ꂼ��9����
    List<bool> haveSkil = new List<bool>() { false, false, false, false, false, false, false, false, false };
    [SerializeField] int skilNo;

    void Start()
    {
        isSkillFinished = true;
        switch (skilNo)
        {
            case 0:
                cost = 10;
                Debug.Log("skil0��������" + cost);
                break;

            case 1:
                cost = 9;
                Debug.Log("skil1��������" + cost);
                break;

            case 2:
                cost = 8;
                Debug.Log("skil2��������" + cost);
                break;

            case 3:
                cost = 7;
                Debug.Log("skil3��������" + cost);
                break;
        }
    }

    //�{�^���N���b�N���ɃA�C�e�������Z�ƒl�i����1.5�{��
    public void OnClick()
    {
        if (haveSkil[skilNo])
        {
            Debug.Log("�w���ςł�");
        }
        else
        {
            Debug.Log(skilNo + "��" + cost + "�ōw�����ꂽ");
            haveSkil[skilNo] = true;
            cost = (int)Math.Round(1.5 * cost);
            isSkillFinished = false;
        }
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "�ōw��";
        SkillPanel.SetActive(isSkillFinished);
    }
}
