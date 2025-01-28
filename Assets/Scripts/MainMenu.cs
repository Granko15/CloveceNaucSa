using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject Abilities;
    [SerializeField] private GameObject QuestionObject;
    private List<QuizQuestion> Questions = new List<QuizQuestion>();
    public void LoadQuestions() 
    {
        string filePath = "Assets/QuizQuestions/questions1.txt";
        List<string> lines = File.ReadAllLines(filePath).ToList();
 
        for(int i = 0; i < lines.Count; i +=7) {
            string questionText = lines[i];
            List<string> options = new List<string>{lines[i+2], lines[i+3], lines[i+4]};
            string answer = lines[i+5];
            QuizQuestion question = new QuizQuestion(questionText, options, answer);
            Questions.Add(question);
        }
        Debug.Log(Questions.Count);
    }

    public QuizQuestion GetRandomQuestion() 
    {
        return Questions[Random.Range(0, Questions.Count - 1)];

    }

    public void Shoot()
    {
        HideAbilitiesPanel();
        Debug.Log("shoot");
    }
    public void Shield() 
    {
        HideAbilitiesPanel();
        Debug.Log("Shield");
    }

       public void SwitchPlaces() 
    {
        HideAbilitiesPanel();
        Debug.Log("Switch");
    }

       public void KnockoutEnemy() 
    {
        HideAbilitiesPanel();
        Debug.Log("KO");
    }



    private void HideAbilitiesPanel()
    {
        Abilities.SetActive(false);
        PrepareQuestion();
        
    }

    private void PrepareQuestion()
    {
        QuizQuestion question = GetRandomQuestion();
        QuestionObject.SetActive(true);
        TextMeshProUGUI triviaQuestion = QuestionObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        triviaQuestion.text = question.GetQuestionText();
        List<string> options = question.GetOptions();
        for (int i = 1; i < 4; i++)
        {
            TextMeshProUGUI optionText = QuestionObject.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>();
            optionText.text = options[i-1];
            QuestionObject.transform.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(() => CheckAnswer(optionText.text, question.GetAnswer()));
        }

    }

    private bool CheckAnswer(string buttonText, string answer)
    {
        if (answer.Equals(buttonText)) 
        { 
            Debug.Log("Correct");

        }
        else 
        {
            Debug.Log("incorrect");

        }
        return answer.Equals(buttonText);
    }
}
