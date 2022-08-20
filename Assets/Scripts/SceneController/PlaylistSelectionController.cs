using System.Collections.Generic;
using UnityEngine;

public class PlaylistSelectionController : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonsParent;

    private List<PlaylistSelectionButton> _playlistSelectionButtons = new List<PlaylistSelectionButton>();

    // Start is called before the first frame update
    private void Start()
    {
        CreateSelectionButtons();
    }

    private void CreateSelectionButtons()
    {
        List<Playlist> playlists = GameManager.Instance.Playlists;

        foreach(Playlist playlist in playlists)
        {
            GameObject button = Instantiate(_buttonPrefab, _buttonsParent);
            PlaylistSelectionButton playlistSelectionButton = button.GetComponent<PlaylistSelectionButton>();
            playlistSelectionButton.Initialize(playlist.ID, playlist.Name);
        }
    }
}
