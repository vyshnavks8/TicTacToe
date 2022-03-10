using UnityEngine;
using UnityEngine.UIElements;

public class GameMenuController : MonoBehaviour
{
    public delegate void ClickAction(int index);
    public static event ClickAction PlayerClicked;
    public Sprite sprite_O, sprite_X;

    private Button[] _buttons=new Button[9];
    private Button _pause, _resume;
    private GroupBox _gameBox;
    private VisualElement _resumeMenu;
    private VisualElement _player1, _player2;

    private void IntialiseUI()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        _player1 = root.Q<VisualElement>("player1");
        _player2 = root.Q<VisualElement>("player2");
        _pause = root.Q<Button>("pause");
        _resume = root.Q<Button>("resume");
        _resumeMenu = root.Q<VisualElement>("ResumeMenu");
        _gameBox = root.Q<GroupBox>("GAMEBOX");

        _buttons[0] = root.Q<Button>("0");
        _buttons[1] = root.Q<Button>("1");
        _buttons[2] = root.Q<Button>("2");
        _buttons[3] = root.Q<Button>("3");
        _buttons[4] = root.Q<Button>("4");
        _buttons[5] = root.Q<Button>("5");
        _buttons[6] = root.Q<Button>("6");
        _buttons[7] = root.Q<Button>("7");
        _buttons[8] = root.Q<Button>("8");

        _resumeMenu.visible = false;
        _player1.style.backgroundColor = Color.yellow;
    }
    private void OnEnable()
    {
        IntialiseUI();
        _pause.clickable.clicked += pauseGame;
        _resume.clickable.clicked += ResumeGame;
        foreach(Button b in _buttons)
        {
            b.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        }
        
    }
    private void OnDisable()
    {
        _pause.clickable.clicked -= pauseGame;
        _resume.clickable.clicked -= ResumeGame;
        foreach (Button b in _buttons)
        {
            b.clickable.clickedWithEventInfo -= (e) => { ButtonClick(e.target); };
        }
    }

    private void ButtonClick(IEventHandler handler)
    {
        Button button = handler as Button;
        VisualElement symbol = button.Q<VisualElement>("symbol");
        int index = int.Parse(button.name);
        if (PlayerManager.IsPlayer1())
        {
            ChangePlayerUI(_player1, _player2, symbol, sprite_O);
        }
        else if (PlayerManager.IsPlayer2())
        {
            ChangePlayerUI(_player2, _player1, symbol, sprite_X);

        }
        PlayerClicked(index);
        button.SetEnabled(false);
    }
    private void ChangePlayerUI(VisualElement activePlayer, VisualElement nextPlayer, VisualElement symbol, Sprite sprite)
    {
        symbol.style.backgroundImage = new StyleBackground(sprite);
        activePlayer.style.backgroundColor = Color.clear;
        nextPlayer.style.backgroundColor = Color.yellow;
    }
    private void pauseGame()
    {
        _gameBox.SetEnabled(false);
        _resumeMenu.visible = true;
    }

    private void ResumeGame()
    {
        _gameBox.SetEnabled(true);
        _resumeMenu.visible = false;
    }
}
