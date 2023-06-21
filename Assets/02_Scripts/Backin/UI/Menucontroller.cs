using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using UnityEngine.SceneManagement;



public class Menucontroller : MonoBehaviour
{
    //[SerializeField]
    private VisualTreeAsset _settingsButtonsTemplate;
    private VisualElement _panelWrapper;
    private VisualElement _endpanel;
    private VisualElement _settingPanel;


    private UIDocument _doc;

    private Button _playButton; //플레이버튼
    private Button _settingsButton; //세팅버튼
    private Button _ExitButton; // 나가기 버튼
    private Button _MuteButton; // 조용히 버튼
    private Button _ExitNoButton; // 나가기 안에 있는 No라는 선택지 버튼
    private Button _exitYesButton; //나가기 안에 있는 yes라는 버튼

    private VisualElement _quit;//바텀시트의 부모
    private VisualElement _quitSheet; //Quit화면 위로 올라가기
    [SerializeField] private UnityEngine.UI.Image _image;



    private void Awake()
    {
        var _doc = GetComponent<UIDocument>();

        _settingPanel = _doc.rootVisualElement.Q<VisualElement>("Setting");

        #region 플레이 버튼
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton"); //플레이 버튼
        _playButton.clicked += PlayButtonOnClicked;
        #endregion

        _endpanel = _doc.rootVisualElement.Q<VisualElement>("Exit"); //게임 종료 창

        _panelWrapper = _doc.rootVisualElement.Q<VisualElement>("LeftSection");//메인 메뉴

        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton"); // 세팅버튼
        _settingsButton.clicked += SettingButtonOnClicked;

        #region 게임 종료 버튼
        _ExitButton = _doc.rootVisualElement.Q<Button>("ExitButton"); //나가는 버튼
        _ExitButton.clicked += ExitButtonOnClicked;

        _ExitNoButton = _doc.rootVisualElement.Q<Button>("NoButton"); // 나가기 버튼 안에 No버튼
        _ExitNoButton.clicked += ExitButton_No;

        _exitYesButton = _doc.rootVisualElement.Q<Button>("YesButton"); //나가기 버튼 안에 Yes버튼
        _exitYesButton.clicked += ExitButton_Yes;
        #endregion
        _MuteButton = _doc.rootVisualElement.Q<Button>("MuteButton");

        //_quit = _doc.rootVisualElement.Q<VisualElement>("Quit-Bottom");
        //_quit.style.display = DisplayStyle.None;


        _quitSheet = _doc.rootVisualElement.Q<VisualElement>("QuitSheet");

    }

    private void ExitButton_Yes()
    {
        _endpanel.AddToClassList("on");
        StartCoroutine(PlayEvent("out"));
    }

    private void SettingButtonOnClicked()
    {
        _settingPanel.RemoveFromClassList("on");
        _panelWrapper.AddToClassList("out");

    }

    private void ExitButtonOnClicked()
    {

        _panelWrapper.AddToClassList("out");
        _endpanel.RemoveFromClassList("on");
        //_quit.style.display = DisplayStyle.Flex;


    }

    private void PlayButtonOnClicked()
    {
        _panelWrapper.AddToClassList("out");
        StartCoroutine(PlayEvent("in"));
    }

    private void ExitButton_No()
    {
        //_quit.style.display = DisplayStyle.None;
        _panelWrapper.RemoveFromClassList("out");
        _endpanel.AddToClassList("on");

    }
    IEnumerator PlayEvent(string what)
    {
        while (true)
        {

            Color myCOlor = _image.color;
            myCOlor.a += 0.01f;
            _image.color = myCOlor;
            yield return new WaitForSeconds(0.01f);
            if (_image.color.a > 0.99f)
            {
                switch (what)
                {
                    case "in":
                        //SceneManager.LoadScene("");
                        break;
                    case "out":
                        Application.Quit();
                        break;
                }
                break;
            }
        }
    }
}
