using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuizManager : MonoBehaviour
{
    private List<QuizQuestionData> quizQuestions;

    void Start()
    {
        // Load questions from JSON file
        string jsonFilePath = Path.Combine(Application.streamingAssetsPath, "questions.json");
        string jsonData = File.ReadAllText(jsonFilePath);

        // Parse JSON into objects
        QuizQuestionList questionList = JsonUtility.FromJson<QuizQuestionList>("{\"questions\":" + jsonData + "}");
        quizQuestions = questionList.questions;

        Debug.Log($"Loaded {quizQuestions.Count} quiz questions.");
    }
}
