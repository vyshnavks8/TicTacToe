using UnityEngine;
using UnityEngine.UIElements;

public class GameMenuController : MonoBehaviour
{
    public delegate int ClickAction(int index);
    public static event ClickAction PlayerClicked;

    public Sprite sprite_O, sprite_X;
    Button b0,b1, b2, b3, b4, b5, b6, b7, b8;
    Button pause,resume;
    GroupBox gameBox;
    VisualElement resumeMenu;
    VisualElement player1, player2;
    private void OnEnable()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        player1 = root.Q<VisualElement>("player1");
        player2 = root.Q<VisualElement>("player2");
        resumeMenu = root.Q<VisualElement>("ResumeMenu");
        pause = root.Q<Button>("pause");
        resume = root.Q<Button>("resume");
        gameBox = root.Q<GroupBox>("GAMEBOX");
        pause.clickable.clicked += PauseGame;
        resume.clickable.clicked += ResumeGame;
        resumeMenu.visible = false;
        player1.style.backgroundColor = Color.yellow;
        

        b0 = root.Q<Button>("0");
        b1 = root.Q<Button>("1");
        b2 = root.Q<Button>("2");
        b3 = root.Q<Button>("3");
        b4 = root.Q<Button>("4");
        b5 = root.Q<Button>("5");
        b6 = root.Q<Button>("6");
        b7 = root.Q<Button>("7");
        b8 = root.Q<Button>("8");

        b0.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        b1.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        b2.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        b3.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        b4.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        b5.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        b6.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        b7.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
        b8.clickable.clickedWithEventInfo += (e) => { ButtonClick(e.target); };
    }

    private void ButtonClick(IEventHandler button)
    {
        Button b = button as Button;
        VisualElement symbol = b.Q<VisualElement>("symbol");
        int index =int.Parse(b.name);
        int player= PlayerClicked(index);
        if (player == 1)
        {
            symbol.style.backgroundImage = new StyleBackground(sprite_O);
            player1.style.backgroundColor = Color.clear;
            player2.style.backgroundColor = Color.yellow;
            
        }
        else
        {
            symbol.style.backgroundImage = new StyleBackground(sprite_X);
            player2.style.backgroundColor = Color.clear;
            player1.style.backgroundColor = Color.yellow;

        }
        b.SetEnabled(false);
    }
    private void PauseGame()
    {
        gameBox.SetEnabled(false);
        resumeMenu.visible = true;
    }

    private void ResumeGame()
    {
        gameBox.SetEnabled(true);
        resumeMenu.visible = false;

    }
}
