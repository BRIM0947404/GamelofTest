using TMPro;
using UnityEngine;

public class AnswerResult : MonoBehaviour
{
    [SerializeField] private GameObject _correctAnswerMark;
    [SerializeField] private GameObject _wrongAnswerMark;
    [SerializeField] private TMP_Text _questionNumberText;
    [SerializeField] private TMP_Text _songNameText;

    public void Initialize(int questionIndex, string songName, bool answeredCorrectly)
    {
        _questionNumberText.text = $"Question {questionIndex}:";
        _songNameText.text = songName;
        _correctAnswerMark.SetActive(answeredCorrectly);
        _wrongAnswerMark.SetActive(!answeredCorrectly);
    }
}
