// ========================================================
// 描述：
// 创建时间：2021-01-06 00:04:17
// ========================================================

using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class NetworkOperations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObservableWWW.Get("http://google.co.jp11")
            .Subscribe(
                x => Debug.Log(x.Substring(0, 100)), // onSuccess
                ex => Debug.LogException(ex)); // onError
    }

    // Update is called once per frame
    void Update()
    {
    }
}