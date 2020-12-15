using UnityEngine;
using Model;
using View;

namespace Controller
{
    public class StorageController : MonoBehaviour
    {
        public bool UpdateCell(int cellID, GameObject boardModel, GameObject boardView, PlayerEnum currentPlayer)
        {
            var cellIsEmpty = boardModel.GetComponent<BoardModel>().GetCellIsEmpty(cellID);
            if (!cellIsEmpty) return false;
            
            ChangeCellContent(cellID, boardView, currentPlayer);
            return true;
        }
        
        private void ChangeCellContent(int cellID, GameObject boardView, PlayerEnum currentPlayer)
        {
            boardView.GetComponent<BoardView>().UpdateCell(cellID, currentPlayer);
        }

        public void RecordPlayerMove(int cellID, PlayerEnum currentPlayer, GameObject playersModel)
        {
            int playerID = currentPlayer == PlayerEnum.X ? 0 : 1;
            int[] coords = ConvertCellIdToCoord(cellID);
            playersModel.GetComponent<PlayersModel>().AddMoves(coords[0], coords[1], playerID);
        }

        private int[] ConvertCellIdToCoord(int cellID)
        {
            int[] coords = new int[2];
            int[] newCoordsMap = {00, 01, 02, 10, 11, 12, 20, 21, 22};
            
            coords[0] = newCoordsMap[cellID] / 10;
            coords[1] = newCoordsMap[cellID] % 10;
            return coords;
        }
    }
}