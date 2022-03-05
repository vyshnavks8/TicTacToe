
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    int count;
    enum Player { p1, p2 };
    enum SymbolState { symbol_O, symbol_X };
    int[] symbolValue;
    Player player;

    private void Start()
    {
        count = 0;
        player = Player.p1;
        symbolValue = new int[9];
        for (int i = 0; i < 9; i++)
        {
            symbolValue[i] = i + 10;
        }
    }
    private void OnEnable()
    {
        GameMenuController.PlayerClicked += PreformLogic;
    }
    private void OnDisable()
    {
        GameMenuController.PlayerClicked -= PreformLogic;
    }
    private int PreformLogic(int index)
    {
        if (player == Player.p1)
        {
            symbolValue[index] = (int)SymbolState.symbol_O;
            player = Player.p2;
        }
        else
        {
            symbolValue[index] = (int)SymbolState.symbol_X;
            player = Player.p1;
        }
        CheckWin();
        return (int)player;
    }
    private void CheckWin()
    {
        count = count + 1;
        //Horizontal Condition Checking
        if (PossibleSoluion(0,1,2))
        {
            EndGame(symbolValue[0]);
        }
        else if (PossibleSoluion(3, 4, 5))
        {
            EndGame(symbolValue[3]);
        }
        else if (PossibleSoluion(6, 7, 8))
        {
            EndGame(symbolValue[6]);
        }
        //Vertical Condition Checking
        else if (PossibleSoluion(0, 3, 6))
        {
            EndGame(symbolValue[0]);
        }
        else if (PossibleSoluion(1, 4, 7))
        {
            EndGame(symbolValue[1]);
        }
        else if (PossibleSoluion(2, 5, 8))
        {
            EndGame(symbolValue[2]);
        }
        //Diagonal Condition Checking
        else if (PossibleSoluion(0, 4, 8))
        {
            EndGame(symbolValue[0]);
        }
        else if (PossibleSoluion(2, 4, 6))
        {
            EndGame(symbolValue[2]);
        }
        //Draw
        else if(count>=9)
        {
            EndGame(-1);
        }
    }
    private void EndGame(int player)
    {
        EndMenuController.winner = player;
        SceneManager.LoadScene(2);
    }
    private bool PossibleSoluion(int x,int y,int z)
    {
        return (symbolValue[x] == symbolValue[y] && symbolValue[x] == symbolValue[z]);
    }
}
