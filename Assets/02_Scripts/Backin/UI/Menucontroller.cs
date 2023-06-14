using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;


public class Menucontroller : MonoBehaviour
{
    private UIDocument _doc;

    private Button _playButton; //플레이버튼
    private Button _settingsButton; //세팅버튼
    private Button _ExitButton; // 나가기 버튼
    private Button _MuteButton; // 조용히 버튼
    private Button _ExitNoButton; // 나가기 안에 있는 No라는 선택지 버튼

    private VisualElement _quit;//바텀시트의 부모
    private VisualElement _quitSheet; //Quit화면 위로 올라가기
    [SerializeField]private UnityEngine.UI.Image _image;

  

    private void Awake()
    {
        var _doc = GetComponent<UIDocument>();
        #region 플레이 버튼
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton"); //플레이 버튼
        _playButton.clicked += PlayButtonOnClicked;
        #endregion
        _settingsButton = _doc.rootVisualElement.Q<Button>("SettingsButton");
        #region 게임 종료 버튼
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
