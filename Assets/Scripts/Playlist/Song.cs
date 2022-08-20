public class Song
{
    private string _id;
    private string _title;
    private string _artist;
    private string _picturePath;
    private string _samplePath;

    public Song(SongData songData)
    {
        _id = songData.id;
        _title = songData.title;
        _artist = songData.artist;
        _picturePath = songData.picture;
        _samplePath = songData.sample;
    }
}
