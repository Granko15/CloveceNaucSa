using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuizQuestionData
{
    public string question;
    public string correctAnswer;
    public List<string> options;
    public string category;
}

[System.Serializable]
public class QuizQuestionList
{
    public List<QuizQuestionData> questions;
}
