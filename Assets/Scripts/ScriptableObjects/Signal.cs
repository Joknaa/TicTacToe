using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects {
    [CreateAssetMenu]
    public class Signal : ScriptableObject {
        public List<SignalListener> Listeners = new List<SignalListener>();
    
        public void Raise()
        {
            for (int i = Listeners.Count -1; i >= 0; i--)
            {
                Listeners[i].OnSignalRaised();
            }
        }

        public void AddListener(SignalListener Listener)
        {
            Listeners.Add(Listener);
        }
    
        public void RemoveListener(SignalListener Listener)
        {
            Listeners.Remove(Listener);
        }
    }
}
