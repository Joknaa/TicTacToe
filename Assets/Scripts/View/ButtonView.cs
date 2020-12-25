using _Scripts.ScriptableObjects;
using UnityEngine;

namespace View {
    
    public class ButtonView : MonoBehaviour {
        public GameObject PlayAgainButton;
        public GameObject QuiteGameButton;
        public Signal PlayAgainSignal;
        public Signal QuitGameSignal;
        
        public void PlayAgainRaise() {
            PlayAgainSignal.Raise();
        }

        public void QuitGameRaise() {
            QuitGameSignal.Raise();
            print("exiting the game");
        }
    }
}