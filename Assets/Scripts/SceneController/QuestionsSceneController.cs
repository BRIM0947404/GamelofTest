using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class QuestionsSceneController : ControllerBase
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonsParent;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AnswerPanelController _answerPanelController;

    private int _questionsIndex = 0;
    private Question _currentQuestion;
    private List<SelectionButton> _selectionsButton = new List<SelectionButton>();
    private Texture _songImage;

    private IEnumerator StarNextAudioClip()
    {
        using (UnityWebRequest wr = UnityWebRequestMultimedia.GetAudioClip(_currentQuestion.Song.SampleURL, AudioType.WAV))
        {
            yield return wr.SendWebRequest();

            if(wr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(wr.error);
            }
            else
            {
                _audioSource.clip = DownloadHandlerAudioClip.GetContent(wr);
                _audioSource.Play();
            }
        }
    }

    private void InitializeNextQuestion()
    {
        _currentQuestion = GameManager.Instance.ActivePlaylist.Questions[_questionsIndex];
        StartCoroutine(StarNextAudioClip());

        for (int i = 0; i < _currentQuestion.Choices.Count; i++)
        {
            Choice choice = _currentQuestion.Choices[i];
            if (_selectionsButton.Count <= 0 || i >= _selectionsButton.Count)
            {
                GameObject button = Instantiate(_buttonPrefab, _buttonsParent);
                SelectionButton selectionButton = button.GetComponent<SelectionButton>();
                selectionButton.OnButtonClicked += OnChoiceSelected;
                _selectionsButton.Add(selectionButton);
            }

            _selectionsButton[i].SetButtonData(i.ToString(), choice.GetChoiceLabel());
        }

        // If there's less choices than buttons
        if(_currentQuestion.Choices.Count < _selectionsButton.Count)
        {
            for(int i = _selectionsButton.Count - 1; i >= _currentQuestion.Choices.Count; i--)
            {
                SelectionButton selectionButton = _selectionsButton[i];
                selectionButton.CleanUp();
                _selectionsButton.RemoveAt(i);
                Destroy(selectionButton);
            }
        }

    }

    private IEnumerator SetAnswerPanelData(bool isCorrectAnswer, string imageURL)
    {
        using (UnityWebRequest wr = UnityWebRequestTexture.GetTexture(imageURL))
        {
            yield return wr.SendWebRequest();

            if (wr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(wr.error);
            }
            else
            {
                Song song = _currentQuestion.Song;
                _songImage = DownloadHandlerTexture.GetContent(wr);
                _answerPanelController.ShowSelectionResult(isCorrectAnswer, song.GetSongNameLabel(), _songImage);
            }
        }
    }

    private void OnChoiceSelected(string id)
    {
        if(_answerPanelController.isActiveAndEnabled)
        {
            return;
        }

        _audioSource.Stop();
        _currentQuestion.AnswerSelected(id);
        StartCoroutine(SetAnswerPanelData(_currentQuestion.AnsweredCorrectly, _currentQuestion.Song.PictureURL));
    }

    private void OnNextQuestionHandler()
    {
        _questionsIndex++;

        if (_questionsIndex >= GameManager.Instance.ActivePlaylist.Questions.Count)
        {
            GameManager.Instance.QuizFinished();
        }
        else
        {
            _answerPanelController.ChangeVisibility(false);
            InitializeNextQuestion();
        }
    }

    public override void Initialize()
    {
        _answerPanelController.OnNextQuestionClicked += OnNextQuestionHandler;
        InitializeNextQuestion();
    }

    public override void CleanUp()
    {
        _answerPanelController.OnNextQuestionClicked -= OnNextQuestionHandler;
    }
}
