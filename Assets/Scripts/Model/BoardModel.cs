using UnityEngine;

namespace Model
{
    public class BoardModel : MonoBehaviour
    {
        public GameObject[] board = new GameObject[9];

        public void SetCellAsFull(int cellID)
        {
            board[cellID].GetComponent<CellModel>().SetCellFull();
        }

        public bool GetCellIsEmpty(int cellID)
        {
            return board[cellID].GetComponent<CellModel>().GetCellIsEmpty();

        }


    }
}