using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestion 
{
    private string QuestionText {get; set;}
    private List<string> Options {get; set;}
    private string Answer {get; set;}

    public QuizQuestion(string questionText, List<string> options, string answer)
    {
        this.QuestionText = questionText;
        this.Options = options;
        this.Answer = answer;
    }

    public string GetQuestionText()
    {
        return this.QuestionText;
    }

    public List<string> GetOptions()
    {
        return this.Options;
    }

    public string GetAnswer() 
    {
        return this.Answer;
    } 
}