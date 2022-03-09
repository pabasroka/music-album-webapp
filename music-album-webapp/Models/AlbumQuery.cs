namespace music_album_webapp.Models;

public class AlbumQuery
{
    public string SearchPhrase { get; set; }
    public string SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}