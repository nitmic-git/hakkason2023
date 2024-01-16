using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ashioto : MonoBehaviour
{
    //Audiocip 配列
    [SerializeField] AudioClip[] clips;
    //足音ピッチ変更範囲
    [SerializeField] float pitchRange = 0.1f;

    //再生するクリップの番号 Animationのキーフレームで変化
    [SerializeField] int AshiotoNumber = 0;
    //AshiotoNumberの変更を検知
    int CurrentValue = 0;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponents<AudioSource>()[0];
        Debug.Log("GetComponents<AudioSource>");
        


        //test 1秒ごとに順番にクリップを再生
        // InvokeRepeating("PlayFootstepSE", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
       if (CurrentValue != AshiotoNumber)
        {
            try
            {
                PlayFootstepSE(); // 再生
            }
            finally
            {
                CurrentValue = AshiotoNumber;
            }
        }
    }
    private void Awake()
    {
        
    }

    public void PlayFootstepSE()
    {
        audioSource.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);
        audioSource.PlayOneShot(clips[AshiotoNumber]);
        Debug.Log("Play: " + AshiotoNumber);

        //以下デバッグ用
        /*
        AshiotoNumber++;
        if (AshiotoNumber == 4)
        {
            AshiotoNumber = 0;
        } */

    }
}
