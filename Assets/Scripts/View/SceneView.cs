using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace View {
    public class SceneView : MonoBehaviour {
        public GameObject PauseMenu;
        public GameObject AboutMenu;
        
        public void OpenScene() {
            SceneManager.LoadScene(1);
        }

        public void ShowAbout() {
            PauseMenu.SetActive(false);
            AboutMenu.SetActive(true);
        }
        
        public void HideAbout() {
            PauseMenu.SetActive(true);
            AboutMenu.SetActive(false);
        }
        
        public void ExitGame() {
            Application.Quit();
        }
    }
}