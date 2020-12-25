using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using View;

namespace Controller
{
    public class GameFlowController : MonoBehaviour {
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
            if (CurrentGameState == GameStateEnum.Pausing) return;
            
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
            DisplayEndGameMenu();
        }

        private void Update() {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (!UIViewScript.pauseMenu.activeInHierarchy) {
                CurrentGameState = GameStateEnum.Pausing;
                UIViewScript.DisplayPauseMenu();
            } else {
                CurrentGameState = GameStateEnum.Playing;
                UIViewScript.HidePauseMenu();
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
        
        private void DisplayEndGameMenu() { // pausing for now ! will make it better later
            CurrentGameState = GameStateEnum.Pausing;
            UIViewScript.DisplayPauseMenu();
        }
        
        public void EndTheGame(){
            Application.Quit();
        }

        public void PlayAgain() {
            SceneManager.LoadScene(0);
        }
    }
}
