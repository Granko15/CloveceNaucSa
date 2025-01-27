using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private List<QuizQuestion> questions = new List<QuizQuestion>();
    public void loadQuestions() 
    {
        string filePath = "Assets/QuizQuestions/questions1.txt";
        List<string> lines = File.ReadAllLines(filePath).ToList();
 
        for(int i = 0; i < lines.Count; i +=7) {
            string questionText = lines[i];
            List<string> options = new List<string>{lines[i+2], lines[i+3], lines[i+4]};
            string answer = lines[i+5];
            QuizQuestion question = new QuizQuestion(questionText, options, answer);
            questions.Add(question);
        }
        Debug.Log(questions.Count);
    }

    public QuizQuestion getRandomQuestion() 
    {
        return questions[Random.Range(0, questions.Count - 1)];

    }
}
