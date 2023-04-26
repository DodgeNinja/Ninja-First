using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    
    [SerializeField] private List<QuizData> quizDatas = new List<QuizData>();

    [SerializeField] private GameObject panel;
    [SerializeField] private Text quizText;
    [SerializeField] private Text ExampleText;
    [SerializeField] private Text returnText;

    public int correct;
    private int nowNumber;

    private void Awake()
    {
        panel.SetActive(false);
        PopPanel(1);
        nowNumber = 1;
    }
    void Update()
    {
        QuizScoring(nowNumber);
    }

    public void PopPanel(int num)
    {
        panel.SetActive(true);

        quizText.text = quizDatas[num - 1].quizText;
        ExampleText.text = quizDatas[num - 1].quizExample;
        correct = quizDatas[num - 1].correctNumber;
    }

    public void QuizScoring(int num)
    {
        if(panel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            if(returnText.text == correct.ToString())
            {
                returnText.text = " ";
                ReturnSuccess(num);
            }
            else
            {
                ReturnFalse();
            }
        }
    }

    void ReturnSuccess(int num)
    {
        PopPanel(++num);
        ++nowNumber;
        
        
    }

    void ReturnFalse()
    {
        returnText.text = "";
        panel.SetActive(false);
    }
}
