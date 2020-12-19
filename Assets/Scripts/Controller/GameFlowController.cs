using Model;
using UnityEditor;
using UnityEngine;
using View;

namespace Controller
{
    public class GameFlowController : MonoBehaviour
    {
        [Header("Models : ")]
        public GameObject boardModel;
        public GameObject playersModel;
        [Header("Views : ")]
        public GameObject boardView;
        public GameObject UIView;
        [Header("Controllers : ")]
        public GameObject storageController;
        public GameObject scoreController;
        public GameObject playerTurnController;

        private GameStateEnum CurrentGameState = GameStateEnum.Playing;
        private PlayerEnum    CurrentPlayer    = PlayerEnum.X;
        private UIView UIViewScript;
        private BoardModel boardModelScript;
        private PlayerTurnController playerTurnControllerScript;
        private StorageController storageControllerScript;
        private ScoreController scoreControllerScript;

        private void Start(){
            UIViewScript = UIView.GetComponent<UIView>();
            storageControllerScript = storageController.GetComponent<StorageController>();
            scoreControllerScript = scoreController.GetComponent<ScoreController>();
            playerTurnControllerScript = playerTurnController.GetComponent<PlayerTurnController>();
            boardModelScript = boardModel.GetComponent<BoardModel>();
        }

        public void PlayTheGame(int cellID){
            GetCurrentPlayer();
            if (UpdateCell(cellID))
            {
                RecordPlayerMove(cellID, CurrentPlayer);
                SetCellAsFull(cellID);
                SetNextPlayer();
                UIViewScript.HideInvalidCellAlert();
            }
            else {
                UIViewScript.DisplayInvalidCellAlert();
            }
            CurrentGameState = CheckCurrentGameState();
            if (CurrentGameState == GameStateEnum.Playing) return;
            
            DisplayResult(CurrentGameState);
            EndTheGame();
        }

        private void Update(){
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!UIViewScript.pauseMenu.activeInHierarchy) {
                    UIViewScript.DisplayPauseMenu();
                    Time.timeScale = 0;    
                } else {
                    UIViewScript.HidePauseMenu();
                    Time.timeScale = 1;
                }
                
            }
        }

        private void DisplayResult(GameStateEnum finalGameStateModel) {
            switch (finalGameStateModel) {
                case GameStateEnum.XWin:
                    print("X win");
                    UIViewScript.DisplayResultXWins();
                    break;
                case GameStateEnum.OWin:
                    print("O win");
                    UIViewScript.DisplayResultOWins();
                    break;
                case GameStateEnum.Draw:
                    print("Draw");
                    UIViewScript.DisplayResultDraw();
                    break;
            }
        }
        
        private void GetCurrentPlayer(){
            CurrentPlayer = playerTurnControllerScript.GetCurrentPlayer();
        }
        
        private bool UpdateCell(int cellID){
            return storageControllerScript.UpdateCell(cellID, boardModel, boardView, CurrentPlayer);
        }
        
        private void SetNextPlayer(){
            playerTurnControllerScript.SetNextPlayer();
        }
        
        private void SetCellAsFull(int cellID){
            boardModelScript.SetCellAsFull(cellID);
        }
        
        private void RecordPlayerMove(int cellID, PlayerEnum currentPlayer){
            storageControllerScript.RecordPlayerMove(cellID, currentPlayer, playersModel);
        }
        
        private GameStateEnum CheckCurrentGameState(){
            return CurrentGameState = scoreControllerScript.CheckCurrentGameState(playersModel, CurrentPlayer);
        }

        private void EndTheGame(){
            Application.Quit();
        }
    }
}
