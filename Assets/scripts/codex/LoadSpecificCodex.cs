using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSpecificCodex : MonoBehaviour{
    //インスペクターで指定をする変数
    [SerializeField] private EnemyDataBase enemyDataBase; //敵のデータベース
    [SerializeField] private GameObject specificWindow; //情報窓(1つのデータ分)
    [SerializeField] private RectTransform contentRectTransform; //Content
    [SerializeField] private Transform ScrollButtonTransform; //スクロールボタン

    //送受信変数
    private int id;
    private bool externalStartEnabled = false;
    //送受信プロパティ
    public int Id{
        get{return id;}
        set{id = value;}
    }
    public bool ExternalStartEnabled{
        get{return externalStartEnabled;}
        set{externalStartEnabled = value;}
    }

    //固有変数
    private FlagManager flagManager;
    private List<Enemy> copyEnemyDataBase;
    private int currentpage; //初期ページ
    private int pageCount; //全体ページ

    void Start(){
        flagManager = GameObject.Find("FlagManager").GetComponent<FlagManager>();
        StartCoroutine(Initialize());
        StartCoroutine(InstantiateSpecificWindow());
    }

    private IEnumerator Initialize(){
        while(!externalStartEnabled) yield return null;
        ScrollButtonController scrollButtonScript = ScrollButtonTransform.GetComponent<ScrollButtonController>(); //スクロールボタンにデータ送信用

        copyEnemyDataBase = new List<Enemy>(enemyDataBase.enemies); //敵データベースをコピー
        currentpage = id + 1; //id(0-)なので+1

        int removedCount = 0;
        for(int i = 0; i < flagManager.IsActiveCodex.Count; i++){ //コピーデータベースからfalseを削除(カウント併用)
            if(!flagManager.IsActiveCodex[i]){
                copyEnemyDataBase.RemoveAt(i - removedCount);
                removedCount++;
                if(i < currentpage - 1) currentpage--;
            }
        }

        pageCount = copyEnemyDataBase.Count; //カウントなのでそのままページ数
        //Send to ScrollButtonController[ページ数, 初期ページ数]
        scrollButtonScript.PageCount = pageCount;
        scrollButtonScript.CurrentPage = currentpage;
        scrollButtonScript.ExternalStartEnabled = true;
    }

    //SpecificWindow生成
    private IEnumerator InstantiateSpecificWindow(){
        for (int i = 0; i < pageCount; i++){
            GameObject specificWindowInstance = Instantiate(specificWindow, contentRectTransform);
            specificWindowInstance.name = $"{specificWindow.name}{i}";
            LoadSpecificInformation specificWindowScript = specificWindowInstance.GetComponent<LoadSpecificInformation>();
            specificWindowScript.Id = i;
            specificWindowScript.CopyEnemyDataBase = new List<Enemy>(copyEnemyDataBase);
            specificWindowScript.ExternalStartEnabled = true;

            yield return null;
        }
    }
    public void OnCloseButtonPressed(){
        Destroy(gameObject);
    }
}
