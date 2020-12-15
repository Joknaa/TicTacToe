using Model;
using UnityEngine;

namespace View
{
    public class CellView : MonoBehaviour
    {
        public Signal clickSignal;
        public Signal playerTurnSignal;
        public GameObject x;
        public GameObject o;
        
        public void OnMouseDown()
        {
            clickSignal.Raise();
            playerTurnSignal.Raise();
        }
        
        public void UpdateCell(PlayerEnum currentPlayer)
        {
            if (currentPlayer == PlayerEnum.X)
            {
                ShowX();
            }
            else
            {
                ShowO();
            }
        }
        private void ShowO()
        {
            x.SetActive(false);
            o.SetActive(true);
        }
        private void ShowX()
        {
            x.SetActive(true);
            o.SetActive(false
            );
        }
    }
}