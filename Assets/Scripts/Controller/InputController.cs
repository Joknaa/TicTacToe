using System;
using Model;
using UnityEngine;

namespace Controller
{
    public class InputController : MonoBehaviour
    {
        public GameObject X;
        public GameObject O;
        private PlayerModel CurrentPlayer;
    
        
        // Start is called before the first frame update
        void Start()
        {
            print("Hey i started !");
            CurrentPlayer = PlayerModel.X;
        }

        private void Update()
        {
            CheckForClicks();
        }

        public void CheckForClicks()
        {
            print("Yoo! you clicked me !! :D");
            switch (CurrentPlayer)
            {
                case PlayerModel.O:
                    O.SetActive(true);
                    X.SetActive(false);
                    CurrentPlayer = PlayerModel.X;
                    break;
                case PlayerModel.X:
                    X.SetActive(true);
                    O.SetActive(false);
                    CurrentPlayer = PlayerModel.O;
                    break;
                default:
                    break;
            }
        }
    }
}
