using System;

[Serializable]
public class SongData
{
    public string id;
    public string title;
    public string artist;
    public string picture;
    public string sample;
}

[Serializable]
public class ChoiceData
{
    public string artist;
    public string title;
}

[Serializable]
public class QuestionData
{
    public string id;
    public int answerIndex;
    public ChoiceData[] choices;
    public SongData song;
}

[Serializable]
public class PlaylistData
{
    public string id;
    public QuestionData[] questions;
    public string playlist;
}
