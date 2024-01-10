using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnGridLayout : MonoBehaviour{
    //インスペクターで指定をする変数
    [SerializeField] private EnemyDataBase enemyDataBase; //敵のデータベース
    [SerializeField] private GameObject selectionWindow; //セレクションウィンドウ(塊)
    [SerializeField] private GameObject buttonCell; //ボタンセル
    [SerializeField] private RectTransform contentRectTransform; //Content指定
    [SerializeField] private Transform scrollButtonTransform; // スクロールボタン指定

    //固有の変数
    private int pageCount; //ページ数
    private int lastPageElement; //最後のページの要素数

    void Start(){
        int elementCount = enemyDataBase.enemies.Count; //データベースの要素数
        //ページ数計算
        pageCount = (elementCount + 11) / 12; // 切り上げ除算でページ数を計算
        lastPageElement = elementCount % 12;

        //ScrollButtonControllerにページ数を送信
        ScrollButtonController scrollButtonController = scrollButtonTransform.GetComponent<ScrollButtonController>();
        scrollButtonController.PageCount = pageCount;
        scrollButtonController.ExternalStartEnabled = true;

        StartCoroutine(InstantiateSelectionWindow());
    }

    // セレクションウィンドウ(塊)を生成する
    private IEnumerator InstantiateSelectionWindow(){
        for (int i = 0; i < pageCount; i++){
            GameObject selectionWindowInstance = Instantiate(selectionWindow, contentRectTransform);
            selectionWindowInstance.name = $"{selectionWindow.name}{i}";

            // セルの生成を待機
            InstantiateGridLayoutCell(i, selectionWindowInstance.GetComponent<RectTransform>());
            yield return null;
        }
    }

    // セルを生成する
    private void InstantiateGridLayoutCell(int currentPage, RectTransform selectionWindowRectTransform){
        int cellsOnThisPage = (currentPage == pageCount - 1) ? lastPageElement : 12;

        for (int j = 0; j < cellsOnThisPage; j++){
            GameObject buttonCellInstance = Instantiate(buttonCell, selectionWindowRectTransform);
            ButtonCell buttonCellScript = buttonCellInstance.GetComponent<ButtonCell>();
            buttonCellScript.Id = currentPage * 12 + j;
            buttonCellScript.ExternalStartEnabled = true;
        }
    }
}