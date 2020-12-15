using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{ 
    public class SwitchCellContentView : MonoBehaviour
    {
        public GameObject X;
        public GameObject O;
        private char CurrentPlayer = 'X';

        public void SetCurrentPlayer(char CurrentPlayer)
        {
            this.CurrentPlayer = CurrentPlayer;
        }
        
        public void ModifyCell()
        {
            if (CurrentPlayer == 'X')
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
            X.SetActive(false);
            O.SetActive(true);
        }

        private void ShowX()
        {
            X.SetActive(true);
            O.SetActive(false
            );
        }
    }
}
