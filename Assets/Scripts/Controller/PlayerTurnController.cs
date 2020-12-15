using Model;
using UnityEngine;

namespace Controller
{
    public class PlayerTurnController : MonoBehaviour
    {
        private PlayerEnum currentPlayer = PlayerEnum.X;

        public void SetNextPlayer()
        {
            currentPlayer = currentPlayer == PlayerEnum.O ? PlayerEnum.X : PlayerEnum.O;
        }
        
        public PlayerEnum GetCurrentPlayer()
        {
            return currentPlayer;
        }
    }
}