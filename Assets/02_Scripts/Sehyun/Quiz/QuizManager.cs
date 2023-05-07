using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public int quizScore;

    Player_NPC_Talk player_NPC_Talk;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] private List<QuizData> quizDatas = new List<QuizData>();

    [SerializeField] private GameObject[] tokPanel;
    [SerializeField] private GameObject panel;
    [SerializeField] private Text quizText;
    [SerializeField] private Text ExampleText;
    [SerializeField] private Text returnText;

    public int correct;
    private int nowNumber;

    private void Awake()
    {
        player_NPC_Talk = FindObjectOfType<Player_NPC_Talk>();

        panel.SetActive(false);
    }
    void Update()
    {
        QuizScoring(nowNumber);
        scoreText.text = $"¸ÂÃá ¹®Á¦ : {quizScore}";
    }

    public void PopPanel(int num)
    {
        tokPanel[num - 1].SetActive(false);
        panel.SetActive(true);

        nowNumber = num;

        quizText.text = quizDatas[num - 1].quizText;
        ExampleText.text = quizDatas[num - 1].quizExample;
        correct = quizDatas[num - 1].correctNumber;
    }

    private void QuizScoring(int num)
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
        StartCoroutine(player_NPC_Talk.Npc_End(num - 1));
        tokPanel[num - 1].SetActive(false);
        quizScore++;
        returnText.text = "";
        panel.SetActive(false);
    }

    void ReturnFalse()
    {
        returnText.text = "";
        panel.SetActive(false);
    }
}
