using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SettingOpen()
    {

    }

    public void GameQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
