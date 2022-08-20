
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameScene
{
    PlaylistSelection,
    Questions,
    GameOver
}

public class SceneFlowManager : MonoBehaviour
{
    private GameScene _currentGameScene = GameScene.PlaylistSelection;
    public static SceneFlowManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeScene(GameScene nextScene)
    {
        string nextSceneName = "";

        switch (nextScene)
        {
            case GameScene.PlaylistSelection: nextSceneName = "PlaylistSelectionScene"; break;
            case GameScene.Questions: nextSceneName = "QuestionsScene"; break;
            case GameScene.GameOver: nextSceneName = "GameOverScene"; break;
        }

        SceneManager.LoadScene(nextSceneName);
    }
}
