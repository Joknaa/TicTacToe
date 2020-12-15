using System;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal signal;
    public UnityEvent SignalEvent;
    public void OnSignalRaised()
    {
        SignalEvent.Invoke();
    }

    private void OnEnable()
    {
        signal.AddListener(this);
    }

    private void OnDisable()
    {
        signal.RemoveListener(this);
    }
}
