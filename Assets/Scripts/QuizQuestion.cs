using System.Collections.Generic;

public class QuizQuestion
{
    private string QuestionText { get; }
    private List<string> Options { get; }
    private string Answer { get; }

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
