using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectionButton : ControllerBase
{
    [SerializeField] private TMP_Text _buttonText;

    private Button _button;
    private string _playlistID;

    public event Action<string> OnButtonClicked;

    public void SetButtonData(string id, string label)
    {
        _playlistID = id;
        _buttonText.text = label;
    }

    public override void Initialize()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => { OnButtonClicked?.Invoke(_playlistID); });
    }

    public override void CleanUp()
    {
        _button.onClick.RemoveAllListeners();
    }
}
