using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsSelecter : MonoBehaviour
{
    //�A�C�e���E�����w����ʂŕ\������{�^��=�i���𒊑I����
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
            Debug.Log(i + "����A�N�e�B�u��");
        }
        //���I��4�̃{�^�����o�����܂�
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