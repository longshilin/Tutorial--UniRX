using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ChinarTest : MonoBehaviour
{
    List<GameObject> gameObjects = new List<GameObject>();
    private ReactiveCollection<GameObject> gameObjectsReactiveCollection /*=new ReactiveCollection<GameObject>()*/;


    /// <summary>
    /// 监听list的值并订阅该值发生变化时进行相应的操作
    /// </summary>
    void Start()
    {
        /*gameObjects.ObserveEveryValueChanged(_ => _.Count).Subscribe(_ => print($"当前操作的gameobject为：{_.ToString()}"));
        for (int i = 0; i < 10; i++)
        {
            gameObjects.Add(new GameObject(i.ToString()));
        }*/

        /*var s = gameObjects.ObserveEveryValueChanged(_ =>
        {
            print(_.Count + "--------");
            return _;
        });
        s.Subscribe(_ => { print(_.Count); });*/

        MethodName();
    }


    /// <summary>
    /// 
    /// </summary>
    private void MethodName()
    {
        for (int i = 0; i < 10; i++)
        {
            gameObjects.Add(new GameObject(i.ToString()));
        }

        gameObjectsReactiveCollection = gameObjects.ToReactiveCollection();
        print(gameObjects.Count);
        print(gameObjectsReactiveCollection.Count);
        gameObjectsReactiveCollection.ObserveAdd().Subscribe(_ => print("添加：" + _));
        gameObjectsReactiveCollection.ObserveMove().Subscribe(_ => print("移除：" + _));
        gameObjectsReactiveCollection.ObserveCountChanged().Subscribe(_ => print("数量：" + _));
        gameObjectsReactiveCollection.ObserveReplace().Subscribe(_ => print("替换：" + _));
        gameObjectsReactiveCollection.ObserveReset().Subscribe(_ => print("重置：" + _));
        print("=============");
        gameObjects.Clear();
        gameObjectsReactiveCollection.Clear();
        gameObjectsReactiveCollection.Dispose();
        print(gameObjects.Count);
        print(gameObjectsReactiveCollection.Count);
    }


    /// <summary>
    /// 每帧刷新
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObjects.Add(new GameObject($"{gameObjects.Count}"));
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (gameObjects.Count > 0)
            {
                var index = gameObjects.Count - 1;
                Destroy(gameObjects[index]);
                gameObjects.RemoveAt(index);
            }
        }
    }
}