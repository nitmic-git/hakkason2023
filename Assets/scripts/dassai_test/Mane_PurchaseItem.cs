using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Mane_PurchaseItem : MonoBehaviour
{
    //�A�C�e�����w�����ď������𑝂₵����A���z�𑝂₵���肷��
    //�����ƃA�C�e���w����ʂ͋��ʂł���A�����ōw����ʂ̕\���E��\��(�E�V�[���J�ڂ�)�Ǘ�����
    //cost�ł��l�i,ShowCost�͒l�D�̖���,itemNo�͊Ǘ��p�Ƀ{�^�����Ɋ��蓖�Ă鐔��
    int cost;
    public GameObject ShowCost;
    //���ꂼ��9����
    List<int> itemAmount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    [SerializeField] int itemNo;
    public GameObject background;
    bool isBackShown;

    void Start()
    {
        isBackShown = true;
        //case0���I���{�^���Ɋ��蓖�Ă�
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

    //�{�^���N���b�N���ɃA�C�e�������Z�ƒl�i����1.5�{��
    public void OnClick()
    {
        if (itemNo == 0)
        {
            isBackShown = false;
        }
        else
        {
            itemAmount[itemNo - 1]++;
            Debug.Log(itemNo + "��" + cost + "�ōw�����ꂽ");
            cost = (int)Math.Round(1.5 * cost);
        }
    }

    void Update()
    {
        ShowCost.GetComponent<Text>().text = cost + "�ōw��";
        background.SetActive(isBackShown);
        //����isbackshown=false�Ȃ�V�[���J�ڂɈڂ�Ƃ�...?
    }
}
