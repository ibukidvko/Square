using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float playTime;
    public float remainingTime;
    public float usedTime=0;

    bool isOver = false;

    public bool isStopped = false;

    public static TimeManager instance { get; private set; }
    private void Awake()
    {
        instance = this;          //为赋值
    }


    private void Start()
    {
        playTime = GameSettings.instance.playTime;
    }

    private void Update()
    {
        if (!isStopped)
        {
            if (isOver) return;

            // 逐帧递减剩余时间
            playTime -= Time.deltaTime;
            remainingTime = playTime;

            usedTime += Time.deltaTime;

            // 当时间归零时只执行一次 GameOver()
            if (playTime <= 0f)
            {
                playTime = 0f;
                isOver = true;
                Debug.Log("游戏结束：时间耗尽");
                GameOver();
            }
        }
    }

    void GameOver()
    {
        // 在这里放置游戏结束后的逻辑（显示面板、停止游戏等）
        Debug.Log("游戏结束逻辑");
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameLoose");
    }
}
