using UnityEngine;

namespace View
{
    public class UIView : MonoBehaviour
    {
        [Header("Interactable UI :")]
        public GameObject mainMenu;
        public GameObject pauseMenu;
        [Header("Alerts :")]
        public GameObject invalidCellAlert;
        [Header("Result Announces :")]
        public GameObject XWins;
        public GameObject OWins;
        public GameObject draw;


        public void DisplayPauseMenu(){
            pauseMenu.SetActive(true);
        }

        public void HidePauseMenu() {
            pauseMenu.SetActive(false);
        }

        public void DisplayInvalidCellAlert(){
            invalidCellAlert.SetActive(true);
        }

        public void HideInvalidCellAlert(){
            invalidCellAlert.SetActive(false);
        }

        public void DisplayResultXWins() {
            XWins.SetActive(true);
        }
        
        public void DisplayResultOWins() {
            OWins.SetActive(true);
        }
        
        public void DisplayResultDraw() {
            draw.SetActive(true);
        }
    }
}