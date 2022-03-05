using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndMenuController : MonoBehaviour
{
    public Sprite player1, player2;
    public Sprite sprite_O, sprite_X;
    public static int winner;
    Label label, playerLabel;
    VisualElement playerBox, symbol, person;
    private void OnEnable()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        Button play = root.Q<Button>("play_again");
        Button main = root.Q<Button>("main_menu");
        symbol = root.Q<VisualElement>("symbol");
        person = root.Q<VisualElement>("person_icon");
        label = root.Q<Label>("label");
        playerLabel = root.Q<Label>("player_label");
        playerBox = root.Q<VisualElement>("playerBox");
        play.clickable.clicked += PlayAgain;
        main.clickable.clicked += MainMenu;
        DrawUI();
    }
    private void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void DrawUI()
    {
        if (winner == 0)
        {
            label.text = "WINNER";
            symbol.style.backgroundImage = new StyleBackground(sprite_O);
            person.style.backgroundImage = new StyleBackground(player1);
            playerLabel.text = "PLAYER 1";
        }
        else if (winner == 1)
        {
            label.text = "WINNER";
            symbol.style.backgroundImage = new StyleBackground(sprite_X);
            person.style.backgroundImage = new StyleBackground(player2);
            playerLabel.text = "PLAYER 2";
        }
        else
        {
            label.text = "DRAW";
            playerBox.visible = false;
        }
    }
}
