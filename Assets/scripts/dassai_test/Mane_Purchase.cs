using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�X�L���w����ʂŕ\������{�^���𒊑I����
public class Mane_Purchase : MonoBehaviour
{
    public GameObject[] Item = new GameObject[30];
    int selecter1;
    int selecter2;
    int selecter3;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 12; i++)
        {
            Item[i].SetActive(false);
            Debug.Log(i + "����A�N�e�B�u��");
        }
        selecter1 = Random.Range(0, 3);
        selecter2 = Random.Range(0, 3) + 3;
        selecter3 = Random.Range(0, 3) + 5;
        Item[selecter1].SetActive(true);
        Item[selecter2].SetActive(true);
        Item[selecter3].SetActive(true);
    }

    void Update()
    {
        
    }
}
