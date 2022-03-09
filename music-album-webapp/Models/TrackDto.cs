namespace music_album_webapp.Models;

public class TrackDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int ReleaseYear { get; set; }
    public int Duration { get; set; } 
}