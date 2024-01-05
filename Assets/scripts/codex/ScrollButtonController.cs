using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollButtonController : MonoBehaviour{
    //インスペクターで指定をする変数
    [SerializeField] private GameObject rightPageMove; //右矢印
    [SerializeField] private GameObject leftPageMove; //左矢印
    [SerializeField] private ScrollRect scrollView; //ScrollView指定
    [SerializeField] private float scrollSpeed = 0.005f;

    //送受信変数
    private int? pageCount; //全ページ数
    private int? currentPage; // 現在のページ数
    private bool externalStartEnabled = false;
    //送受信プロパティ
    public int PageCount{
        get{return (int)pageCount;}
        set{pageCount = value;}
    }
    public int CurrentPage{
        get{return (int)currentPage;}
        set{currentPage = value;}
    }
    public bool ExternalStartEnabled{
        get{return externalStartEnabled;}
        set{externalStartEnabled = value;}
    }

    //固有変数
    private float targetHorizontalPosition;

    void Start(){
        StartCoroutine(Initialize());
    }

    void Update(){
        // スクロールのアニメーション
        scrollView.horizontalNormalizedPosition = Mathf.Lerp(scrollView.horizontalNormalizedPosition, targetHorizontalPosition, scrollSpeed);
    }

    public void OnRightButtonPress(){
        // スクロールをトリガーする処理
        currentPage += 1;
        SetTargetHorizontalPosition();
        ButtonTransform();
    }

    public void OnLeftButtonPress(){
        // スクロールをトリガーする処理
        currentPage -= 1;
        SetTargetHorizontalPosition();
        ButtonTransform();
    }

    //目標座標の設定
    private void SetTargetHorizontalPosition(){
        targetHorizontalPosition = pageCount != 1 ? ((float)(currentPage - 1) / (float)(pageCount - 1)) : 0.0f;
    }

    //ボタンの作成/削除
    void ButtonTransform(){
        GameObject rightButton = transform.Find("RightPageMove")?.gameObject;
        GameObject leftButton = transform.Find("LeftPageMove")?.gameObject;

        if(rightButton != null && currentPage == pageCount){
            Destroy(rightButton);
        }else if (rightButton == null && currentPage != pageCount){
            CreateButton(rightPageMove, "RightPageMove", OnRightButtonPress);
        }

        if (leftButton != null && currentPage == 1){
            Destroy(leftButton);
        } else if (leftButton == null && currentPage != 1){
            CreateButton(leftPageMove, "LeftPageMove", OnLeftButtonPress);
        }
    }

    //ボタンの作成
    private void CreateButton(GameObject buttonPrefab, string buttonName, UnityEngine.Events.UnityAction buttonAction){
        GameObject instance = Instantiate(buttonPrefab, transform);
        instance.name = buttonName;
        Button buttonScript = instance.GetComponent<Button>();
        buttonScript.onClick.AddListener(buttonAction);
    }

    private IEnumerator Initialize(){
        yield return new WaitUntil(() => externalStartEnabled);
        if(currentPage == null) currentPage = 1; //現在のページが送信されなかったとき

        SetTargetHorizontalPosition(); //初期位置設定
        ButtonTransform(); // 初回のボタン配置
    }

}
