public class Song
{
    private string _id;
    private string _title;
    private string _artist;
    private string _pictureURL;
    private string _sampleURL;

    public string PictureURL => _pictureURL;
    public string SampleURL => _sampleURL;

    public Song(SongData songData)
    {
        _id = songData.id;
        _title = songData.title;
        _artist = songData.artist;
        _pictureURL = songData.picture;
        _sampleURL = songData.sample;
    }

    public string GetSongNameLabel()
    {
        return $"{_title} - {_artist}";
    }
}
