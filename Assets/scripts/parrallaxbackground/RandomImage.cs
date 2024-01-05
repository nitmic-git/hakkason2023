using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Folder;

public class RandomImage : MonoBehaviour{
    [SerializeField, Header("何枚ごとにランダムで変更するか")] 
    int Num_Randomization;

    [SerializeField, Header("存在する画像数")] 
    int Num_Texture;

    [Folder, Header("フォルダのパス")]
    public string m_folder;

    Sprite tmp;
    [HideInInspector] public List<Sprite> texture_list = new List<Sprite>();
    private Transform[] children;
    private HorizontalDynamicImageRotation[] script;
    int count, random;
    bool Randomization;

    private void Awake(){
        //子オブジェクト,スクリプトの取得
        children = new Transform[transform.childCount]; 
        script = new HorizontalDynamicImageRotation[transform.childCount]; //呼ぶスクリプトにあだなつける
        for (var i = 0; i < children.Length; i++){
            children[i] = transform.GetChild(i);
            script[i] = children[i].GetComponent<HorizontalDynamicImageRotation>();
        }
        //リソースから表示させたい画像を指定した個数だけ読み込む
        for (int i = 0; i < Num_Texture; i++){
            tmp = LoadSprite(m_folder.ToFolderInfo().path + "/" + (i + 1) + ".png");
            texture_list.Add(tmp);
        }
        count = 0; //カウントの初期化
        random = 0; //ランダムの初期化(最初に表示する画像を"1.png"にすること)
        Randomization = false;
    }

    private void Update(){
        for (var i = 0; i < children.Length; i++){
            if (script[i].hasTransformed){
                if (texture_list[random] != children[i].GetComponent<SpriteRenderer>().sprite){
                    children[i].GetComponent<SpriteRenderer>().sprite = texture_list[random];
                }
                script[i].hasTransformed = false;
                count += 1;
                Randomization = true;
                break;
            }
        }
        if (Randomization && count % Num_Randomization == 0){
            random = Random.Range(0, texture_list.Count);
            Randomization = false;
        }
        Debug.Log(count);
    }

    // ユーティリティ
    public static Sprite LoadSprite(string path){
        try{
            var rawData = System.IO.File.ReadAllBytes(path);
            Texture2D texture2D = new Texture2D(0, 0);
            texture2D.LoadImage(rawData);
            var sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height),
                new Vector2(0.5f, 0.5f), 100f);
            return sprite;
        }
        catch (System.Exception){
            return null;
        }
    }
}
