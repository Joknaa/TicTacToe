using System;
using System.Collections.Generic;
using Model;
using UnityEngine;
using View;

namespace Controller
{
    public class InputController : MonoBehaviour
    {
        public PlayerEnum CurrentPlayer;
        public SwitchCellContentView SwitchCellContentViewScript;

        void Start()
        {
            print("Hey i started !");
            CurrentPlayer = PlayerEnum.X;
        }

        private void Update()
        {
            CheckCurrentPlayerInView();
        }

        private void CheckCurrentPlayerInView()
        {
            SwitchCellContentViewScript.SetCurrentPlayer(CurrentPlayer == PlayerEnum.O ? 'O' : 'X');
        }

    }
}
