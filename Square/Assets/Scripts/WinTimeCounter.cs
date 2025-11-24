using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinTimeCounter : MonoBehaviour
{
    public FloatDataSO timeUsedSO;
    public float timeUsed;

    public GameObject textMeshPro;

    public static WinTimeCounter instance { get; private set; }         //创建一个对象，可在其他东西里调用   （可以用属性的方式包装一下）
    private void Awake()
    {
        instance = this;          //为赋值
        ReadTime();
    }
    private void Start()
    {
        SetUITime();
    }
    public float ReadTime()
    {
        timeUsed = timeUsedSO.floatValue;
        return timeUsed;
    }

    void SetUITime()
    {
        if (textMeshPro == null)
        {
            Debug.LogWarning("WinTimeCounter: textMeshPro 未赋值。请在 Inspector 中分配包含 TextMeshPro 的 GameObject。");
            return;
        }

        TextMeshPro tmp = textMeshPro.GetComponent<TextMeshPro>();
        TextMeshProUGUI tmpUGUI = textMeshPro.GetComponent<TextMeshProUGUI>();

        if (tmp == null && tmpUGUI == null)
        {
            Debug.LogWarning("WinTimeCounter: 目标物体上未找到 TextMeshPro 或 TextMeshProUGUI 组件。");
            return;
        }

        int seconds = Mathf.RoundToInt(timeUsed);
        string display = $"花费{seconds}秒";

        if (tmp != null)
            tmp.text = display;
        else
            tmpUGUI.text = display;
    }
}
