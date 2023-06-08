using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Menucontroller : MonoBehaviour
{
    private UIDocument _doc;
    private Button _playButton;
    private Button _settingsButton;
    private Button _ExitButton;
    private Button _MuteButton;
    [SerializeField]private UnityEngine.UI.Image _image;
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _playButton.clicked += PlayButtonOnClicked;

        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");

        _ExitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
        _ExitButton.clicked += ExitButtonOnClicked;

        _MuteButton = _doc.rootVisualElement.Q<Button>("MuteButton");

    }

    private void ExitButtonOnClicked()
    {
        Debug.Log("³¢¸ðÂî");
        Application.Quit();
    }

    private void PlayButtonOnClicked()
    {
        StartCoroutine(PlayEvent());
    }

    IEnumerator PlayEvent()
    {
        while (true)
        {
            Color myCOlor = _image.color;
            myCOlor.a += 0.01f;
            _image.color = myCOlor;
            yield return new WaitForSeconds(0.01f);
            if (_image.color.a > 0.99f)
            {
            
                break;
            }
        }
    }
}
