using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T: MonoBehaviourSingleton<T>
{
    private static T instance;
 
    public static T Instance
    {
        get
        {
            if (instance != null) return instance;
            var go = new GameObject("MonoBehaviourCallbacks");
            DontDestroyOnLoad(go);
            instance = go.AddComponent<T>();
            return instance;
        }
    }
}
