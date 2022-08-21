using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameScene
{
    WelcomeScreen,
    QuizScreen,
    ResultsScreen
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextAsset playlistsJSONData;

    private PlaylistData[] _playlistsData;
    private List<Playlist> _playlists = new List<Playlist>();
    private Playlist _activePlaylist;
    private int _correctAnswercount;

    public List<Playlist> Playlists => _playlists;
    public Playlist ActivePlaylist => _activePlaylist;

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

    private void ChangeScene(GameScene nextScene)
    {
        string nextSceneName = "";

        switch (nextScene)
        {
            case GameScene.WelcomeScreen: nextSceneName = "WelcomeScene"; break;
            case GameScene.QuizScreen: nextSceneName = "QuizScene"; break;
            case GameScene.ResultsScreen: nextSceneName = "ResultsScene"; break;
        }

        SceneManager.LoadScene(nextSceneName);
    }

    public void ShowPlaylists()
    {
        ChangeScene(GameScene.WelcomeScreen);
    }

    public void PlaylistSelected(string id)
    {
        _correctAnswercount = 0;

        foreach (Playlist playlist in _playlists)
        {
            if(playlist.ID.Equals(id))
            {
                _activePlaylist = playlist;
                _activePlaylist.ResetPlaylist();
                ChangeScene(GameScene.QuizScreen);
            }
        }
    }

    public void QuizFinished()
    {
        ChangeScene(GameScene.ResultsScreen);
    }
}
