using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPanelController : ControllerBase
{
    [SerializeField] private GameObject _correctAnswerMark;
    [SerializeField] private GameObject _wrongAnswerMark;
    [SerializeField] private TMP_Text _resultText;
    [SerializeField] private TMP_Text _answerText;
    [SerializeField] private RawImage _answerImage;
    [SerializeField] private Button _nextButton;

    public event Action OnNextQuestionClicked;

    public void ShowSelectionResult(bool isCorrectAnswer, string songName, Texture songImage)
    {
        _resultText.text = (isCorrectAnswer) ? "You Guessed Right!" : "Sorry! Wrong Answer.";
        _correctAnswerMark.SetActive(isCorrectAnswer);
        _wrongAnswerMark.SetActive(!isCorrectAnswer);
        _answerText.text = songName;
        _answerImage.texture = songImage;
        ChangeVisibility(true);
    }

    public void ChangeVisibility(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }

    public override void Initialize()
    {
        ChangeVisibility(false);
        _nextButton.onClick.AddListener(() => { OnNextQuestionClicked?.Invoke(); });
    }

    public override void CleanUp()
    {
        _nextButton.onClick.RemoveAllListeners();
    }
}
