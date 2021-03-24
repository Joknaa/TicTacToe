using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View {
    public class ButtonView : MonoBehaviour {
        public GameObject PlayAgainButton;
        public GameObject QuiteGameButton;
        public Signal PlayAgainSignal;
        
        public void PlayAgainRaise() {
            PlayAgainSignal.Raise();
        }
        
        public void OpenScene() {
            SceneManager.LoadScene(0);
        }
    }
}