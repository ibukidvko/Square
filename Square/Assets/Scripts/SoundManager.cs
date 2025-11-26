using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("事件监听")]
    public VoidEventSO ClickSoundSO;

    [Header("广播")]
    public VoidEventSO PlayClickSoundSO;

    private void OnEnable()     //注册事件
    {
        //将函数加入订阅中
        ClickSoundSO.OnEventRaised += OnClickSound;
    }
    private void OnDisable()    //取消注册,下次通知时就不会受到通知
    {
        ClickSoundSO.OnEventRaised -= OnClickSound;
    }

    private void OnClickSound()
    {
        Debug.Log("播放音效");
        PlayClickSoundSO.RaiseEvent();
    }
}
