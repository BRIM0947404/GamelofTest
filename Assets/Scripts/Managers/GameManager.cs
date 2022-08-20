using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextAsset playlistsJSONData;

    private PlaylistData[] _playlistsData;
    private List<Playlist> _playlists = new List<Playlist>();

    public List<Playlist> Playlists => _playlists;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            CreatePlaylistFromJSON();
            DontDestroyOnLoad(gameObject);
        }
    }

    private void CreatePlaylistFromJSON()
    {
        _playlistsData = JSONUtils.ReadJSONFile<PlaylistData[]>(playlistsJSONData);
        foreach (PlaylistData playlistData in _playlistsData)
        {
            _playlists.Add(new Playlist(playlistData));
        }
    }
}
