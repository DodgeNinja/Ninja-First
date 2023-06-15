using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;



public class Menucontroller : MonoBehaviour
{
    //[SerializeField]
    private VisualTreeAsset _settingsButtonsTemplate;
    private VisualElement _buttonsWrapper;
    private VisualElement _panelWrapper;
    private VisualElement _endpanel;


    private UIDocument _doc;

    private Button _playButton; //�÷��̹�ư
    private Button _settingsButton; //���ù�ư
    private Button _ExitButton; // ������ ��ư
    private Button _MuteButton; // ������ ��ư
    private Button _ExitNoButton; // ������ �ȿ� �ִ� No��� ������ ��ư
    private Button _exitYesButton; //������ �ȿ� �ִ� yes��� ��ư

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

        _endpanel = _doc.rootVisualElement.Q<VisualElement>("Quit-Bottom");

        _panelWrapper = _doc.rootVisualElement.Q<VisualElement>("LeftSection");//���� �޴�

        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton"); // ���ù�ư
        _settingsButton.clicked += SettingButtonOnClicked;

        #region ���� ���� ��ư
        _ExitButton = _doc.rootVisualElement.Q<Button>("ExitButton"); //������ ��ư
        _ExitButton.clicked += ExitButtonOnClicked;

        _ExitNoButton = _doc.rootVisualElement.Q<Button>("NoButton"); // ������ ��ư �ȿ� No��ư
        _ExitNoButton.clicked += ExitButton_No;

        _exitYesButton = _doc.rootVisualElement.Q<Button>("YesButton"); //������ ��ư �ȿ� Yes��ư
        _exitYesButton.clicked += ExitButton_Yes;
        #endregion
        _MuteButton = _doc.rootVisualElement.Q<Button>("MuteButton");

        //_quit = _doc.rootVisualElement.Q<VisualElement>("Quit-Bottom");
        //_quit.style.display = DisplayStyle.None;


        _quitSheet = _doc.rootVisualElement.Q<VisualElement>("QuitSheet");
    }

    private void ExitButton_Yes()
    {
        _endpanel.RemoveFromClassList("on");
        StartCoroutine(PlayEvent());
    }

    private void SettingButtonOnClicked()
    {
        _buttonsWrapper.Clear();
    }

    private void ExitButtonOnClicked()
    {
        _panelWrapper.AddToClassList("out");
        _endpanel.AddToClassList("on");
        //_quit.style.display = DisplayStyle.Flex;


    }

    private void PlayButtonOnClicked()
    {
        _panelWrapper.AddToClassList("out");       
        StartCoroutine(PlayEvent());
    }

    private void ExitButton_No()
    {
        //_quit.style.display = DisplayStyle.None;
        _panelWrapper.RemoveFromClassList("out");
        _endpanel.RemoveFromClassList("on");

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
