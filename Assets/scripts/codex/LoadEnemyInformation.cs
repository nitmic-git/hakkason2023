using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEnemyInformation : MonoBehaviour{
    //インスペクターで指定をする変数
    [SerializeField] private EnemyDataBase enemyDataBase; //敵のデータベース
    [SerializeField] private GameObject specificCodex; //詳細

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

    private FlagManager flagManager;

    //固有定数

    void Start(){
        flagManager = GameObject.Find("FlagManager").GetComponent<FlagManager>();
        StartCoroutine(Initialize());
    }

    public void OnSpecificButtonPress(){
        GameObject specificCodexInstance = Instantiate(specificCodex);
        LoadSpecificCodex specificCodexScript = specificCodexInstance.GetComponent<LoadSpecificCodex>();
        specificCodexScript.Id = id;
        specificCodexScript.ExternalStartEnabled = true;
    }

    private IEnumerator Initialize(){
        while(!externalStartEnabled) yield return null;

        Enemy targetEnemy = enemyDataBase.enemies[id];
        
        //データを表示するTransform取得
        Transform hpTransform = transform.Find("HP");
        Transform powerTransform = transform.Find("Power");

        //テキスト、画像取得
        Text nameText = transform.Find("Name").GetComponent<Text>();
        Image imageComponent = transform.Find("Image").GetComponent<Image>();
        Text hpText = hpTransform.Find("Text").GetComponent<Text>();
        Text powerText = powerTransform.Find("Text").GetComponent<Text>();

        nameText.text = targetEnemy.Name;
        imageComponent.sprite = targetEnemy.sprite;
        hpText.text = targetEnemy.hp.ToString();
        powerText.text  = targetEnemy.power.ToString();
    }
}
