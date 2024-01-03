using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsSelecter : MonoBehaviour
{
    public GameObject[] Item = new GameObject[9];
    int selecter1;
    int selecter2;
    int selecter3;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<=8; i++)
        {
            Item[i].SetActive(false);
            Debug.Log(i + "が非アクティブ化");
        }
        selecter1 = Random.Range(0, 3);
        selecter2 = Random.Range(0, 3) + 3;
        selecter3 = Random.Range(0, 3) + 6;
        Item[selecter1].SetActive(true);
        Item[selecter2].SetActive(true);
        Item[selecter3].SetActive(true);

    }

    /*
    public void OnClick()
    {
        selecter1 = Random.Range(0,3);
        selecter2 = Random.Range(0, 3) + 3;
        selecter3 = Random.Range(0, 3) + 6;
        Item[selecter1].SetActive(true);
        Item[selecter2].SetActive(true);
        Item[selecter3].SetActive(true);
    }
    */

}