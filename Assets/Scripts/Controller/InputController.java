
import Model.BoardModel;
import View.InputView;
import View.OutputView;

public class InputController {
    OutputView outputView   = new OutputView();
    int[] InputCoords = new int[2];

    public int[] ValidateInput(BoardModel gameBoardModel) {
        boolean ValidInput = true;
        do {
            ValidInput = CheckInput(gameBoardModel, InputView.GetInput());
        } while (!ValidInput);

        return InputCoords;
    }
}