using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    private Button _play, _quit;
    private void IntialiseUI()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;
        _play = root.Q<Button>("play");
        _quit = root.Q<Button>("quit");
    }
    private void OnEnable()
    {
        IntialiseUI();
        _play.clickable.clicked += PlayGame;
        _quit.clickable.clicked += QuitGame;
    }
    private void OnDisable()
    {
        _play.clickable.clicked -= PlayGame;
        _quit.clickable.clicked -= QuitGame;
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
