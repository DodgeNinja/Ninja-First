using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/QuizData")]
public class QuizData : ScriptableObject
{
    public string quizText;
    public string quizExample;
    public int correctNumber;
}

