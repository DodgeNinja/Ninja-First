using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    QuizManager quizManager;

    [SerializeField] float maxScore;
    [SerializeField] Image image;

    private void Awake()
        => quizManager = FindObjectOfType<QuizManager>();

    void Update()
    {
        if (StatManager.instance.willPower <= 0)
        {
            image.DOFade(1, 1).OnComplete(() => {
                SceneManager.LoadScene("Gay");
            });
        }

        if (quizManager.quizScore >= maxScore)
        {
            image.DOFade(1, 1).OnComplete(() => {
                SceneManager.LoadScene("GameOver");
            });
        }
    }
}
