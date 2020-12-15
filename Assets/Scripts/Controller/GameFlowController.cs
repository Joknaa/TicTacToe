using Model;
using UnityEngine;

namespace Controller
{
    public class GameFlowController : MonoBehaviour
    {
        [Header("Models : ")]
        public GameObject boardModel;
        public GameObject playersModel;
        [Header("Views : ")]
        public GameObject boardView;
        [Header("Controllers : ")]
        public GameObject storageController;
        public GameObject scoreController;
        public GameObject playerTurnController;

        private GameStateEnum CurrentGameState = Model.GameStateEnum.Playing;
        private PlayerEnum    CurrentPlayer = PlayerEnum.X;

        public void PlayTheGame(int cellID)
        {
            GetCurrentPlayer();
            if (UpdateCell(cellID))
            {
                RecordPlayerMove(cellID, CurrentPlayer);
                SetCellAsFull(cellID);
                SetNextPlayer();
            }
            else // for now ..
            {
                print("PlayTheGame : Cell is full !!");
            }
            CurrentGameState = CheckCurrentGameState();
            if (CurrentGameState != GameStateEnum.Playing)
            {
                DisplayResult(CurrentGameState);
                EndTheGame();
            }
        }
        
        public void DisplayResult(GameStateEnum finalGameStateModel){
            //char FinalGameStateSymbol = ' ';

            if      (finalGameStateModel == GameStateEnum.XWin) { print("X win");}
            else if (finalGameStateModel == GameStateEnum.OWin) { print("O win");}
            else if (finalGameStateModel == GameStateEnum.Draw)  { print("Draw");}
            //Display.DisplayGameState(FinalGameStateSymbol);
        }
        private void GetCurrentPlayer()
        {
            CurrentPlayer = playerTurnController.GetComponent<PlayerTurnController>().GetCurrentPlayer();
        }
        private bool UpdateCell(int cellID)
        {
            return storageController.GetComponent<StorageController>().UpdateCell(
                cellID, boardModel, boardView, CurrentPlayer);
        }
        private void SetNextPlayer()
        {
            playerTurnController.GetComponent<PlayerTurnController>().SetNextPlayer();
        }
        private void SetCellAsFull(int cellID)
        {
            boardModel.GetComponent<BoardModel>().SetCellAsFull(cellID);
        }
        private void RecordPlayerMove(int cellID, PlayerEnum currentPlayer)
        {
            storageController.GetComponent<StorageController>().RecordPlayerMove(
                cellID, currentPlayer, playersModel);
        }
        private GameStateEnum CheckCurrentGameState()
        {
            return CurrentGameState = scoreController.GetComponent<ScoreController>().
                CheckCurrentGameState(playersModel, CurrentPlayer);
        }

        private void EndTheGame()
        {
            Application.Quit();
        }
    }
}
