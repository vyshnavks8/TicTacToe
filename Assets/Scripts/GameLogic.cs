
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    private int _count;
    private PlayerManager.Symbols[] _symbolTable;

    private void Start()
    {
        _count = 0;
        _symbolTable = new PlayerManager.Symbols[9];
        PlayerManager.Player = PlayerManager.Players.P1;
        PlayerManager.Symbol = PlayerManager.Symbols.O;
        for (int i = 0; i < 9; i++)
        {
            _symbolTable[i] = PlayerManager.Symbols.E;
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

    private void PreformLogic(int index)
    {
        _symbolTable[index] = PlayerManager.Symbol;
        PlayerManager.ChangePlayer();
        CheckWin();
    }
    private void CheckWin()
    {
        _count = _count + 1;
        //Horizontal Condition Checking
        if (PossibleSoluion(0, 1, 2))
        {
            EndGame(0);
        }
        else if (PossibleSoluion(3, 4, 5))
        {
            EndGame(3);
        }
        else if (PossibleSoluion(6, 7, 8))
        {
            EndGame(6);
        }
        //Vertical Condition Checking
        else if (PossibleSoluion(0, 3, 6))
        {
            EndGame(0);
        }
        else if (PossibleSoluion(1, 4, 7))
        {
            EndGame(1);
        }
        else if (PossibleSoluion(2, 5, 8))
        {
            EndGame(2);
        }
        //Diagonal Condition Checking
        else if (PossibleSoluion(0, 4, 8))
        {
            EndGame(0);
        }
        else if (PossibleSoluion(2, 4, 6))
        {
            EndGame(2);
        }
        //Draw
        else if (_count >= 9)
        {
            EndGame(-1);
        }
    }
    private void EndGame(int index)
    {
        if (index == -1)
        {
            PlayerManager.SetDraw();
            SceneManager.LoadScene(2);
        }
        else
        {
            PlayerManager.Symbols symbol = _symbolTable[index];
            PlayerManager.SetWinner(symbol);
            SceneManager.LoadScene(2);
        }

    }
    private bool PossibleSoluion(int x, int y, int z)
    {
        if (_symbolTable[x] != PlayerManager.Symbols.E && _symbolTable[y] != PlayerManager.Symbols.E && _symbolTable[z] != PlayerManager.Symbols.E)
        {
            return (_symbolTable[x] == _symbolTable[y] && _symbolTable[x] == _symbolTable[z]);
        }
        else
        {
            return false;
        }

    }
}
