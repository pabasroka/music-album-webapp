namespace music_album_webapp.Models;

public class Pagination<T>
{
    public IEnumerable<T> Items { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }


    public Pagination(IEnumerable<T> items, int totalItems, int currentPage, int paginationSize)
    {
        Items = items;
        TotalItems = totalItems;
        TotalPages = (int) Math.Ceiling((double) TotalItems / paginationSize);
        ItemsFrom = paginationSize * (currentPage - 1) + 1;
        ItemsTo = ItemsFrom + paginationSize - 1;
    }
}