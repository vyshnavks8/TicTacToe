public class PlayerManager
{
    public enum Players { D, P1, P2 };
    public enum Symbols { E, O, X };

    private static Players _player;
    private static Symbols _symbol;

    public static Players Player
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }
    }

    public static Symbols Symbol
    {
        get
        {
            return _symbol;
        }
        set
        {
            _symbol = value;
        }
    }

    public static void ChangePlayer()
    {
        if (IsPlayer1())
        {
            _player = Players.P2;
            _symbol = Symbols.X;
        }
        else if (IsPlayer2())
        {
            _player = Players.P1;
            _symbol = Symbols.O;
        }
    }

    public static bool IsPlayer1()
    {
        return _player == Players.P1;
    }

    public static bool IsPlayer2()
    {
        return _player == Players.P2;
    }

    public static void SetWinner(Symbols _symbol)
    {
        if (_symbol == Symbols.O)
        {
            _player = Players.P1;
        }
        else if (_symbol == Symbols.X)
        {
            _player = Players.P2;
        }
    }
    public static void SetDraw()
    {
        _player = Players.D;
    }

}
