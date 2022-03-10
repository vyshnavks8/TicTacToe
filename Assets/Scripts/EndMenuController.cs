using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndMenuController : MonoBehaviour
{
    public Sprite player1, player2;
    public Sprite sprite_O, sprite_X;

    private Label _label, _playerLabel;
    private VisualElement _playerBox, _symbol, _person;
    private Button _play, _main;
    private void IntialiseUI()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        _play = root.Q<Button>("play_again");
        _main = root.Q<Button>("main_menu");
        _symbol = root.Q<VisualElement>("symbol");
        _person = root.Q<VisualElement>("person_icon");
        _label = root.Q<Label>("label");
        _playerLabel = root.Q<Label>("player_label");
        _playerBox = root.Q<VisualElement>("playerBox");
    }
    private void OnEnable()
    {
        IntialiseUI();
        DrawWinnerUI();
        _play.clickable.clicked += PlayAgain;
        _main.clickable.clicked += MainMenu;

    }
    private void OnDisable()
    {
        _play.clickable.clicked -= PlayAgain;
        _main.clickable.clicked -= MainMenu;
    }
    private void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void DrawWinnerUI()
    {
        if (PlayerManager.IsPlayer1())
        {
            SetWinnerDetail("WINNER", "PLAYER 1", player1, sprite_O);
        }
        else if (PlayerManager.IsPlayer2())
        {
            SetWinnerDetail("WINNER", "PLAYER 2", player2, sprite_X);
        }
        else
        {
            _label.text = "DRAW";
            _playerBox.visible = false;
        }
    }
    private void SetWinnerDetail(string label, string playerLabel, Sprite person, Sprite symbol)
    {
        _label.text = label;
        _playerLabel.text = playerLabel;
        _person.style.backgroundImage = new StyleBackground(person);
        _symbol.style.backgroundImage = new StyleBackground(symbol);
    }
}
