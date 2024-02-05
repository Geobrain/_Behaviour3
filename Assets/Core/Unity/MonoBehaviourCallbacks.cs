using System;
using System.Collections.Generic;
using UnityEngine;

//MonoBehaviourCallbacks.Instance.AddListener(MessageType.OnUpdate, OnUpdate);  // OnUpdate - метод, который дергается в апдейте
public enum MessageType {
    OnFixUpdate,
    OnUpdate,
    OnLostFocus,
    OnGainedFocus,
    OnApplicationQuit,
    OnGUI,
}

public class MonoBehaviourCallbacks : MonoBehaviourSingleton<MonoBehaviourCallbacks> {
    public delegate void MessageCallback();
    private Dictionary<MessageType, MessageCallback> _messageCallbacks = new ();

    private void BroadcastMessage(MessageType messageType) {
        BroadcastUnityMessage(messageType);
    }

    private void BroadcastUnityMessage(MessageType messageType) {
        MessageCallback callback;
        if (_messageCallbacks.TryGetValue(messageType, out callback)) {
            if (callback != null) {
                callback();
            }
        }
    }

    public void AddListener(MessageType messageType, MessageCallback callback) => AddListenerToUnityMessage(messageType, callback);

    private void AddListenerToUnityMessage(MessageType messageType, MessageCallback callback) {
        if (!_messageCallbacks.ContainsKey(messageType)) {
            _messageCallbacks.Add(messageType, null);
        }

        _messageCallbacks[messageType] += callback;
    }

    public void RemoveListener(MessageType messageType, MessageCallback callback) => RemoveListenerToUnityMessage(messageType, callback);

    private void RemoveListenerToUnityMessage(MessageType messageType, MessageCallback callback) {
        if (_messageCallbacks.ContainsKey(messageType)) {
            _messageCallbacks[messageType] -= callback;
        }
    }

    #region Unity Event Message functions

    private void FixedUpdate() => BroadcastMessage(MessageType.OnFixUpdate);
    
    private void Update() => BroadcastMessage(MessageType.OnUpdate);

    private void OnApplicationPause(bool isPaused) =>
        BroadcastMessage(isPaused
            ? MessageType.OnLostFocus
            : MessageType.OnGainedFocus);

    private void OnApplicationFocus(bool hasFocus) => BroadcastMessage(hasFocus ? MessageType.OnGainedFocus : MessageType.OnLostFocus);

    private void OnApplicationQuit() {
#if UNITY_EDITOR
        BroadcastMessage(MessageType.OnLostFocus);
#endif
        BroadcastMessage(MessageType.OnApplicationQuit);
    }

    private void OnGUI() => BroadcastMessage(MessageType.OnGUI);

    #endregion
}