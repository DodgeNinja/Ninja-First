using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOverController : MonoBehaviour
{
    private UIDocument document;
    private VisualElement GameOverPanel;
    private Button restart;
    private Button quit;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        GameOverPanel = document.rootVisualElement.Q("GameOverPanel");

        restart = document.rootVisualElement.Q<Button>("Restart");
        restart.clicked += Restart;

        quit = document.rootVisualElement.Q<Button>("Quit");
        quit.clicked += Quit;
    }

    private void GameOver()
    {
        GameOverPanel.AddToClassList("on");
    }

    private void Restart()
    {
        GameOverPanel.RemoveFromClassList("on");
    }

    private void Quit()
    {
        Application.Quit();
    }
}
