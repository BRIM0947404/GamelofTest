using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlaylistSelectionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _buttonText;

    private Button _button;
    private string _playlistID;

    public event Action<string> OnButtonClicked;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener( () => { OnButtonClicked?.Invoke(_playlistID); });
    }

    public void Initialize(string id, string playlistName)
    {
        _playlistID = id;
        _buttonText.text = playlistName;
    }
}
