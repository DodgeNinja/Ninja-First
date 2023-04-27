using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneManagerEX : MonoBehaviour
{
    [SerializeField] private Image blackBack;
    [SerializeField] private float time = 1.0f;

    static private Image BlackBack;
    static private float Time;

    private void Awake()
    {
        BlackBack = blackBack;
        Time = time;

        BlackBack.enabled = false;
    }

    public void SceneLoader(string sceneName)
    {
        
    }

    public void GameQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
