using System.Collections.Generic;

public class Playlist
{
    private string _id;
    private string _name;
    private List<Question> _questions = new List<Question>();

    public string ID => _id;
    public string Name => _name;
    public List<Question> Questions => _questions;

    public Playlist(PlaylistData playlistData)
    {
        _id = playlistData.id;
        _name = playlistData.playlist;
        foreach(QuestionData questionData in playlistData.questions)
        {
            _questions.Add(new Question(questionData));
        }
    }

    public void ResetPlaylist()
    {
        foreach(Question question in _questions)
        {
            question.ResetQuestion();
        }
    }
}
