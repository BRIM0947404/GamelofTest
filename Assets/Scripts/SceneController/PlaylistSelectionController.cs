using System.Collections.Generic;
using UnityEngine;

public class PlaylistSelectionController : ControllerBase
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonsParent;

    private List<SelectionButton> _playlistSelectionButtons = new List<SelectionButton>();

    private void CreateSelectionButtons()
    {
        List<Playlist> playlists = GameManager.Instance.Playlists;

        foreach(Playlist playlist in playlists)
        {
            GameObject button = Instantiate(_buttonPrefab, _buttonsParent);
            SelectionButton playlistSelectionButton = button.GetComponent<SelectionButton>();
            playlistSelectionButton.SetButtonData(playlist.ID, playlist.Name);
            playlistSelectionButton.OnButtonClicked += OnPlaylistSelectionButtonHandler;
            _playlistSelectionButtons.Add(playlistSelectionButton);
        }
    }

    private void OnPlaylistSelectionButtonHandler(string id)
    {
        GameManager.Instance.PlaylistSelected(id);
    }

    public override void Initialize()
    {
        CreateSelectionButtons();
    }

    public override void CleanUp()
    {
        foreach (SelectionButton playlistSelectionButton in _playlistSelectionButtons)
        {
            playlistSelectionButton.OnButtonClicked -= OnPlaylistSelectionButtonHandler;
        }
        _playlistSelectionButtons.Clear();
    }
}
