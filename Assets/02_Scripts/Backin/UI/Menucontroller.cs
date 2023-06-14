using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;


public class Menucontroller : MonoBehaviour
{
    private UIDocument _doc;

    private Button _playButton; //�÷��̹�ư
    private Button _settingsButton; //���ù�ư
    private Button _ExitButton; // ������ ��ư
    private Button _MuteButton; // ������ ��ư
    private Button _ExitNoButton; // ������ �ȿ� �ִ� No��� ������ ��ư

    private VisualElement _quit;//���ҽ�Ʈ�� �θ�
    private VisualElement _quitSheet; //Quitȭ�� ���� �ö󰡱�
    [SerializeField]private UnityEngine.UI.Image _image;

  

    private void Awake()
    {
        var _doc = GetComponent<UIDocument>();
        #region �÷��� ��ư
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton"); //�÷��� ��ư
        _playButton.clicked += PlayButtonOnClicked;
        #endregion
        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");
        #region ���� ���� ��ư
        _ExitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
        _ExitButton.clicked += ExitButtonOnClicked;
        #endregion
        _MuteButton = _doc.rootVisualElement.Q<Button>("MuteButton");

        _quit = _doc.rootVisualElement.Q<VisualElement>("Quit-Bottom");
        _quit.style.display = DisplayStyle.None;

        _ExitNoButton = _doc.rootVisualElement.Q<Button>("NoButton");
        _ExitNoButton.clicked += ExitButton_No;

        _quitSheet = _doc.rootVisualElement.Q<VisualElement>("QuitSheet");
    }

    private void ExitButtonOnClicked()
    {
        _quit.style.display = DisplayStyle.Flex;


    }

    private void PlayButtonOnClicked()
    {
        StartCoroutine(PlayEvent());
    }

    private void ExitButton_No()
    {
        _quit.style.display = DisplayStyle.None;

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
