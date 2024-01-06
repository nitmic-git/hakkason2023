using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonCell : MonoBehaviour{
    //インスペクターで指定をする変数
    [SerializeField] private EnemyDataBase enemyDataBase; //敵のデータベース
    [SerializeField] private GameObject enemyInformation;
    [SerializeField] private Sprite blackImage; //黒
    
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

    //固有定数
    private Transform canvas;
    private FlagManager flagManager;

    void Start(){
        //シーン"Codex"に属するCanvasを検索
        Scene codex = SceneManager.GetSceneByName("Codex");
        GameObject[] rootObjects = codex.GetRootGameObjects();
        foreach(GameObject obj in rootObjects){
            if(obj.name == "Canvas"){
                canvas = obj.GetComponent<Transform>();
                break;
            }
        }

        flagManager = GameObject.Find("FlagManager").GetComponent<FlagManager>();
        StartCoroutine(Initialize());
    }

    public void OnClick(){
        //現在のInformationを検索
        GameObject currentInformation = canvas.Find("NonInformation")?.gameObject;

        if(currentInformation == null){
            currentInformation = canvas.Find("EnemyInformation").gameObject;
        }
        StartCoroutine(DestroyAndCreate(currentInformation));
    }

    private IEnumerator Initialize(){
        while(!externalStartEnabled) yield return null;

        Enemy targetEnemy = enemyDataBase.enemies[id]; //idの敵を取得

        //データを表示するTransform取得
        Transform imageTransform = transform.Find("Viewport");

        //テキスト、画像取得
        Text nameText = transform.Find("Name").GetComponent<Text>();
        Image imageComponent = imageTransform.Find("Image").GetComponent<Image>();

        if(flagManager.IsActiveCodex[id]){
            nameText.text = targetEnemy.Name;
            imageComponent.sprite = targetEnemy.sprite;
        }else{
            nameText.text = "unknown";
            imageComponent.sprite = blackImage;
            transform.Find("Button").GetComponent<Button>().interactable = false;
        }
    }

    private IEnumerator DestroyAndCreate(GameObject objToDestroy){
        if (objToDestroy != null){
            //削除して1フレーム待機
            Destroy(objToDestroy);
            yield return new WaitForEndOfFrame();

            GameObject enemyInformationInstance = Instantiate(enemyInformation, canvas);
            LoadEnemyInformation enemyInformationScript = enemyInformationInstance.GetComponent<LoadEnemyInformation>();
            enemyInformationInstance.name = enemyInformation.name;
            enemyInformationScript.Id = id;
            enemyInformationScript.ExternalStartEnabled = true;
        }
    }
}
