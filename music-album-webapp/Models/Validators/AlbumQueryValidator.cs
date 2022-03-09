using FluentValidation;
using music_album_webapp.Entities;

namespace music_album_webapp.Models.Validators;

public class AlbumQueryValidator : AbstractValidator<AlbumQuery>
{
    private string[] _allowedSortByColumnNames =
    {
        nameof(Album.Author),
        nameof(Album.Title),
        nameof(Album.ReleaseYear),
    };

    public AlbumQueryValidator()
    {
        RuleFor(s => s.SortBy)
            .Must(value => string.IsNullOrEmpty(value) || _allowedSortByColumnNames.Contains(value));
    }
}