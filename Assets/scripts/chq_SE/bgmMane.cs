using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bgmMane : MonoBehaviour
{
    //clips
    public AudioClip BGM_title;
    public AudioClip BGM_main;
    //�g�p����AudioSource
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        //�g�p����AudioSource�擾
        source = GetComponent<AudioSource>();

        //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
        SceneManager.activeSceneChanged += OnActiveSceneChanged;

        source.clip = BGM_title; //�^�C�g���Ȃ𗬂�
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //�V�[�����ǂ��ς�������Ŕ���

        //title
        if (nextScene.name == "TitleScene")
        {
            source.Stop();
            source.clip = BGM_title; //�^�C�g���Ȃ𗬂�
            source.Play();
        }else{
            source.Stop();
            source.clip = BGM_main;    //������
            source.Play();
        }
    }

}
