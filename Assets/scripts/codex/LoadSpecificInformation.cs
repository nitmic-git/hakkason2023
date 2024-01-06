using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSpecificInformation : MonoBehaviour{
    public EnemyDataBase enemyDataBase;

    //送受信変数
    private int id;
    private List<Enemy> copyEnemyDataBase;
    private bool externalStartEnabled = false;
    //送受信プロパティ
    public int Id{
        get{return id;}
        set{id = value;}
    }
    public List<Enemy> CopyEnemyDataBase{
        get{return copyEnemyDataBase;}
        set{copyEnemyDataBase = value;}
    }
    public bool ExternalStartEnabled{
        get{return externalStartEnabled;}
        set{externalStartEnabled = value;}
    }

    void Start(){
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize(){
        while (!externalStartEnabled) yield return null;

        Enemy targetEnemy = copyEnemyDataBase[id];

        Transform hpTransform = transform.Find("HP");
        Transform powerTransform = transform.Find("Power");
        
        Text nameText = transform.Find("Name").GetComponent<Text>();
        Image imageComponent = transform.Find("Image").GetComponent<Image>();
        Text hpText = hpTransform.Find("Text").GetComponent<Text>();
        Text powerText = powerTransform.transform.Find("Text").GetComponent<Text>();
        Text informationText = transform.Find("Information").GetComponent<Text>();

        nameText.text = targetEnemy.Name;
        imageComponent.sprite = targetEnemy.sprite;
        hpText.text = targetEnemy.hp.ToString();
        powerText.text = targetEnemy.power.ToString();
        informationText.text = targetEnemy.information;
    }
}
