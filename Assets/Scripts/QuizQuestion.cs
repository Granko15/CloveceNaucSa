using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestion 
{
    private string questionText {get; set;}
    private List<string> options {get; set;}
    private string answer {get; set;}

    public QuizQuestion(string questionText, List<string> options, string answer)
    {
        this.questionText = questionText;
        this.options = options;
        this.answer = answer;
    }
}