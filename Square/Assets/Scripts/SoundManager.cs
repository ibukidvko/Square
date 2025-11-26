using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// 确保游戏对象上存在 AudioSource 组件
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [Header("事件监听")]
    // VoidEventSO 是一种 ScriptableObject，用于事件系统
    public VoidEventSO ClickSoundSO;

    [Header("音效设置")]
    // 存放所有点击音效的数组，可以放多个不同的音效
    public AudioClip[] clickClips;

    // 用于播放音效的组件
    private AudioSource audioSource;

    private void Awake()
    {
        // 获取 AudioSource 组件
        audioSource = GetComponent<AudioSource>();

        // 注册事件：使用 Awake 注册，更早、更稳定
        if (ClickSoundSO != null)
        {
            ClickSoundSO.OnEventRaised += OnClickSound;
        }
        else
        {
            Debug.LogError("ClickSoundSO 事件对象未分配给 SoundManager，请在 Inspector 中设置！", this);
        }
    }

    private void OnDestroy()
    {
        // 取消注册事件：使用 OnDestroy 取消注册，确保对象销毁时解除订阅
        if (ClickSoundSO != null)
        {
            ClickSoundSO.OnEventRaised -= OnClickSound;
        }
    }

    /// <summary>
    /// 响应 ClickSoundSO 事件，播放点击音效。
    /// </summary>
    private void OnClickSound()
    {
        Debug.Log("--- 接收到音效事件，尝试播放音效 ---");

        if (clickClips != null && clickClips.Length > 0)
        {
            // 确保 Random.Range 不会越界
            AudioClip clipToPlay = clickClips[UnityEngine.Random.Range(0, clickClips.Length)];

            // 🔴 关键检查：在播放前确认 clipToPlay 是否为空
            if (clipToPlay != null)
            {
                audioSource.PlayOneShot(clipToPlay);
                Debug.Log($"✅ 正在播放音效: {clipToPlay.name}");
            }
            else
            {
                // ⚠️ 如果你看到这个，就找到了问题！说明数组里有空槽位。
                Debug.LogError("🔴 错误：Click Clips 数组中包含了空的 AudioClip (null)！", this);
            }
        }
        else
        {
            Debug.LogWarning("未设置点击音效 (clickClips)，无法播放。", this);
        }
    }
}