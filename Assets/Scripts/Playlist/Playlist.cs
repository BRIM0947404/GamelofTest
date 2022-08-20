using System.Collections.Generic;

public class Playlist
{
    private string _id;
    private List<Question> _questions = new List<Question>();
    private string _name;

    public string ID => _id;
    public string Name => _name;

    public Playlist(PlaylistData playlistData)
    {
        _id = playlistData.id;
        _name = playlistData.playlist;
        foreach(QuestionData questionData in playlistData.questions)
        {
            _questions.Add(new Question(questionData));
        }
    }
}
