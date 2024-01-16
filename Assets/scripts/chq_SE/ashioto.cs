using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ashioto : MonoBehaviour
{
    //Audiocip �z��
    [SerializeField] AudioClip[] clips;
    //�����s�b�`�ύX�͈�
    [SerializeField] float pitchRange = 0.1f;

    //�Đ�����N���b�v�̔ԍ� Animation�̃L�[�t���[���ŕω�
    [SerializeField] int AshiotoNumber = 0;
    //AshiotoNumber�̕ύX�����m
    int CurrentValue = 0;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponents<AudioSource>()[0];
        Debug.Log("GetComponents<AudioSource>");
        


        //test 1�b���Ƃɏ��ԂɃN���b�v���Đ�
        // InvokeRepeating("PlayFootstepSE", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
       if (CurrentValue != AshiotoNumber)
        {
            try
            {
                PlayFootstepSE(); // �Đ�
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

        //�ȉ��f�o�b�O�p
        /*
        AshiotoNumber++;
        if (AshiotoNumber == 4)
        {
            AshiotoNumber = 0;
        } */

    }
}
