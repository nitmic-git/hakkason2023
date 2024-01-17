using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgmMane : MonoBehaviour
{
    //clips
    public AudioClip BGM_title;
    public AudioClip BGM_main;
    //使用するAudioSource
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //使用するAudioSource取得
        source = GetComponent<AudioSource>();

        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;

        source.clip = BGM_title; //タイトル曲を流す
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //シーンが切り替わった時に呼ばれるメソッド
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //シーンがどう変わったかで判定

        //title
        if (nextScene.name == "TitleScene")
        {
            source.Stop();
            source.clip = BGM_title; //タイトル曲を流す
            source.Play();
        }else{
            source.Stop();
            source.clip = BGM_main;    //道中曲
            source.Play();
        }
    }

}
