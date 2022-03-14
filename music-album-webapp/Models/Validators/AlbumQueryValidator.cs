using FluentValidation;
using music_album_webapp.Entities;

namespace music_album_webapp.Models.Validators;

public class AlbumQueryValidator : AbstractValidator<AlbumQuery>
{
    private readonly string[] _allowedSortByColumnNames =
    {
        nameof(Album.Author),
        nameof(Album.Title),
        nameof(Album.ReleaseYear),
    };

    private readonly int[] _allowedPaginationSize = new[] {5, 10, 20, 50};

    public AlbumQueryValidator()
    {
        RuleFor(s => s.SortBy)
            .Must(value => string.IsNullOrEmpty(value) || _allowedSortByColumnNames.Contains(value));

        RuleFor(r => r.CurrentPage).GreaterThanOrEqualTo(1);
        RuleFor(r => r.PaginationSize).Custom((value, context) =>
        {
            if (!_allowedPaginationSize.Contains(value))
            {
                context.AddFailure("Wrong pagination size");
            }
        });
    }
}