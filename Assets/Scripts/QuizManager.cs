using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    private List<QuizQuestionData> quizQuestions;
    public static string selectedAgeGroup; 

    void Start()
    {
        string jsonFileName = $"{PlayerPrefs.GetString("selectedAgeGroup")}.json";
        Debug.Log($"Selected age group: {jsonFileName}");
        string jsonFilePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);

        if (File.Exists(jsonFilePath))
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            QuizQuestionList questionList = JsonUtility.FromJson<QuizQuestionList>("{\"questions\":" + jsonData + "}");
            quizQuestions = questionList.questions;

            Debug.Log($"Loaded {quizQuestions.Count} quiz questions for age group {selectedAgeGroup}.");
        }
        else
        {
            Debug.LogError($"JSON file not found: {jsonFilePath}");
        }
    }
}
