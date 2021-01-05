// ========================================================
// 描述：
// 以下代码实现了双击检测示例
//
// 此示例演示了以下功能（仅五行！）：
//      作为事件流的游戏循环（更新）
//      可组合的事件流
//      合并自身流
//      基于时间易于处理的操作
// 创建时间：2021-01-05 23:44:13
// ========================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var clickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0));
        // 用一个buffer来装载，在一个指定的时间单元内所有的对象操作集
        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromMilliseconds(250)))
            .Where(xs => xs.Count >= 2)
            .Subscribe(xs => Debug.Log($"DoubleClick Detected! Count: {xs.Count}"));
    }

    // Update is called once per frame
    void Update()
    {
    }
}