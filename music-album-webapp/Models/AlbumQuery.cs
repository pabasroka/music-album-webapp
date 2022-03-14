namespace music_album_webapp.Models;

public class AlbumQuery
{
    public string SearchPhrase { get; set; }
    public string SortBy { get; set; }
    public int? ReleaseYear { get; set; } = null;
    public SortDirection SortDirection { get; set; }
    
    public int CurrentPage { get; set; }
    public int PaginationSize { get; set; }
}