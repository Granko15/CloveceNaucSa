using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject Abilities;
    [SerializeField] private GameObject QuestionObject;
    [SerializeField] private GameObject Player1Name;
    [SerializeField] private GameObject Player2Name;
    [SerializeField] private TurnManager turnManager;
    public SoundEffectsPlayer soundEffectsPlayer;

    private List<QuizQuestion> Questions = new List<QuizQuestion>();
    private QuizQuestion CurrentQuestion;

    void Awake()
    {
        Abilities.SetActive(false);
        QuestionObject.SetActive(false);

    }

    void Start()
    {
        LoadQuestionsFromJson();
    }

    public void LoadQuestionsFromJson()
    {
        string jsonFileName = $"{PlayerPrefs.GetString("selectedAgeGroup")}";
        Debug.Log($"Selected age group: {jsonFileName}");
        TextAsset jsonFile = Resources.Load<TextAsset>($"QuizQuestions/{jsonFileName}");
        if (jsonFile == null)
        {
            Debug.LogError("Failed to load JSON file from Resources/QuizQuestions/questions.json");
            return;
        }

        // Parse JSON into objects
        QuizQuestionList quizData = JsonUtility.FromJson<QuizQuestionList>(jsonFile.text);

        // Create QuizQuestion objects from QuizQuestionData
        foreach (var data in quizData.questions)
        {
            QuizQuestion question = new QuizQuestion(data.question, data.options, data.correctAnswer);
            Questions.Add(question);
        }

        Debug.Log($"Loaded {Questions.Count} questions from JSON.");
    }

    public QuizQuestion GetRandomQuestion()
    {
        if (Questions.Count == 0)
        {
            Debug.LogError("No questions available.");
            return null;
        }
        return Questions[Random.Range(0, Questions.Count)];
    }

    public void Shoot()
    {
        HideAbilitiesPanel();
        Debug.Log("Shoot ability selected.");
        Player currentPlayer = turnManager.GetCurrentPlayer();
        currentPlayer.SetAbilityToUse("Shoot");
    }

    public void Shield()
    {
        HideAbilitiesPanel();
        Debug.Log("Shield ability selected.");
        Player currentPlayer = turnManager.GetCurrentPlayer();
        currentPlayer.SetAbilityToUse("Shield");
    }

    public void Heal()
    {
        HideAbilitiesPanel();
        Debug.Log("Heal ability selected.");
        Player currentPlayer = turnManager.GetCurrentPlayer();
        if (currentPlayer.CanHealAPawn())
        {
            currentPlayer.Heal();
        }
        
    }

    private void HideAbilitiesPanel()
    {
        Abilities.SetActive(false);
        PrepareQuestion();
    }

    private void ShowAbilitiesPanel()
    {
        Abilities.SetActive(true);
    }

    private void PrepareQuestion()
    {
        CurrentQuestion = GetRandomQuestion();
        if (CurrentQuestion == null) return;

        QuestionObject.SetActive(true);

        // Set the question text
        TextMeshProUGUI triviaQuestion = QuestionObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        triviaQuestion.text = CurrentQuestion.GetQuestionText();

        // Set the answer options and attach listeners
        List<string> options = CurrentQuestion.GetOptions();
        for (int i = 1; i <= 3; i++)
        {
            int optionIndex = i - 1;  // Correctly capture the option index
            TextMeshProUGUI optionText = QuestionObject.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>();
            Button optionButton = QuestionObject.transform.GetChild(i).GetComponent<Button>();

            // Set the option text
            optionText.text = options[optionIndex];

            // Clear previous listeners and attach a new one
            optionButton.onClick.RemoveAllListeners();
            string selectedOption = options[optionIndex];
            optionButton.onClick.AddListener(() => OnOptionSelected(selectedOption));
        }
    }

    private void OnOptionSelected(string selectedOption)
    {
        CheckAnswer(selectedOption, CurrentQuestion.GetAnswer());
    }

    public void CheckAnswer(string playerAnswer, string correctAnswer)
    {
        if (playerAnswer == correctAnswer)
        {
            Debug.Log("Correct! Ability activated.");
            soundEffectsPlayer.PlayCorrectAnswerSound();
            turnManager.PlayerAnsweredCorrectly();
        }
        else
        {
            Debug.Log("Incorrect! Skipping turn.");
            soundEffectsPlayer.PlayWrongAnswerSound();
            turnManager.PlayerAnsweredIncorrectly();
        }

        QuestionObject.SetActive(false);
    }
}