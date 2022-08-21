using System.Collections.Generic;

public class Question
{
    private string _id;
    private int _answerIndex;
    private List<Choice> _choices = new List<Choice>();
    private Song _song;
    private bool _answeredCorrectly;

    public List<Choice> Choices => _choices;
    public Song Song => _song;
    public bool AnsweredCorrectly => _answeredCorrectly;

    public Question(QuestionData questionData)
    {
        _id = questionData.id;
        _answerIndex = questionData.answerIndex;
        _song = new Song(questionData.song);
        foreach (ChoiceData choiceData in questionData.choices)
        {
            _choices.Add(new Choice(choiceData));
        }
    }

    public void AnswerSelected(string choiceId)
    {
        _answeredCorrectly = choiceId.Equals(_answerIndex.ToString());
    }

    public void ResetQuestion()
    {
        _answeredCorrectly = false;
    }
}
