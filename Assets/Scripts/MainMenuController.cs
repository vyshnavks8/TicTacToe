using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        Button play = root.Q<Button>("play");
        Button quit = root.Q<Button>("quit");
        play.clickable.clicked += PlayGame;
        quit.clickable.clicked += QuitGame;
    }
    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
