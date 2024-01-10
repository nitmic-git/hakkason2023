using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseSkil : MonoBehaviour
{
    //cost�ł��l�i,ShowCost�͒l�D�̖���,Skillpanel�͍w���̔w�i�ɂȂ���
    int cost;
    public GameObject ShowCost;
    public GameObject SkillPanel;
    bool isSkillshown;
    //���ꂼ��9����
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
            isSkillshown = false;
        }
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "�ōw��";
        SkillPanel.SetActive(isSkillshown);
    }
}
