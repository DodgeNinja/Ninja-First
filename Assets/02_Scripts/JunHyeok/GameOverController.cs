using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverController : MonoBehaviour
{
    private Ending ending;
    private UIDocument _uiDocument;
    private VisualElement GameOverPanel;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
        ending = FindObjectOfType<Ending>();
    }

    private void OnEnable()
    {
        VisualElement root = _uiDocument.rootVisualElement;

        Button btn = root.Q<Button>("Restart");

        btn.RegisterCallback<ClickEvent>(e =>
        {
            SceneManager.LoadScene("Game");
        });

        Button btnQuit = root.Q<Button>("Quit");

        btnQuit.RegisterCallback<ClickEvent>(e =>
        {
            GameOver();
        });
    }

    private void GameOver()
    {
        Application.Quit();
        Debug.Log("GameOver");
    }

    private void Update()
    {
        if (ending.gameOver == true)
        {
            VisualElement root = _uiDocument.rootVisualElement;

            VisualElement popupWindow = root.Q("GameOverPanel");

            popupWindow.AddToClassList("off");
        }
    }
}
