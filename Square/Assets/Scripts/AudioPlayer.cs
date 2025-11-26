using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("事件监听")]
    public VoidEventSO PlayClickSoundSO;


    public AudioSource ads;
    public AudioClip startSound;     //可拖入音频片段

    private void Awake()
    {
        ads = GetComponent<AudioSource>();
        ads.clip = startSound;       //定义
    }

    private void OnEnable()     //注册事件
    {
        //将函数加入订阅中
        PlayClickSoundSO.OnEventRaised += PlayClickSound;
    }
    private void OnDisable()    //取消注册,下次通知时就不会受到通知
    {
        PlayClickSoundSO.OnEventRaised -= PlayClickSound;
    }



    public void PlayClickSound()
    {
        ads.Play();         //播放音频
    }
   


}
