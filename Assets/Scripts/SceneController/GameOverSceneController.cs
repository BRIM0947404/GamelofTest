using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSceneController : ControllerBase
{
    [SerializeField] private GameObject _resultPrefab;
    [SerializeField] private Transform _resultsParent;
    [SerializeField] private TMP_Text _totalScoreText;
    [SerializeField] private Button _nextButton;

    private List<AnswerResult> _answerResults = new List<AnswerResult>();

    public override void Initialize()
    {
        int score = 0;
        List<Question> questions = GameManager.Instance.ActivePlaylist.Questions;
        for (int i = 0; i < questions.Count; i++)
        { 
            Question question = questions[i];
            GameObject result = Instantiate(_resultPrefab, _resultsParent);
            AnswerResult answerResult = result.GetComponent<AnswerResult>();
            _answerResults.Add(answerResult);
            answerResult.Initialize(i + 1, question.Song.GetSongNameLabel(), question.AnsweredCorrectly);

            if (question.AnsweredCorrectly)
            {
                score++;
            }
        }

        _totalScoreText.text = $"Your Score: {score}/{questions.Count}";
        _nextButton.onClick.AddListener(GameManager.Instance.ShowPlaylists);
    }

    public override void CleanUp()
    {
        _nextButton.onClick.RemoveAllListeners();
    }
}
