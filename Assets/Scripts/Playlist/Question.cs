using System.Collections.Generic;

public class Question
{
    private string _id;
    private int _answerIndex;
    private List<Choice> _choices = new List<Choice>();
    private Song _song;

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
}
