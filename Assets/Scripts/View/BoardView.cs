using Model;
using UnityEngine;

namespace View
{
    public class BoardView : MonoBehaviour
    {
        public GameObject[] board = new GameObject[9];
        
        public void UpdateCell(int cellID, PlayerEnum currentPlayer)
        {
            board[cellID].GetComponent<CellView>().UpdateCell(currentPlayer);
        }

    }
}