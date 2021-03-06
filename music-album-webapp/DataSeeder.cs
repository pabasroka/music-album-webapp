using music_album_webapp.Entities;

namespace music_album_webapp;

public class DataSeeder
{
    private readonly DataContext _dataContext;

    public DataSeeder(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void Seed()
    {
        if (_dataContext.Database.CanConnect())
        {
            if (!_dataContext.Roles.Any())
            {
                var roles = GetRoles();
                _dataContext.Roles.AddRange(roles);
                _dataContext.SaveChanges();
            }
            
            if (!_dataContext.Distributions.Any())
            {
                var distributions = GetDistributions();
                _dataContext.Distributions.AddRange(distributions);
                _dataContext.SaveChanges();
            }

            if (!_dataContext.Users.Any())
            {
                var users = GetUsers();
                _dataContext.Users.AddRange(users);
                _dataContext.SaveChanges();
            }
            
            if (!_dataContext.Albums.Any())
            {
                var albums = GetAlbums();
                _dataContext.Albums.AddRange(albums);
                _dataContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Role> GetRoles()
    {
        var roles = new List<Role>()
        {
            new Role()
            {
                Name = "User"
            },
            new Role()
            {
                Name = "Manager"
            },
            new Role()
            {
                Name = "Admin"
            },
        };

        return roles;
    }
    
    private IEnumerable<Distribution> GetDistributions()
    {
        var distributions = new List<Distribution>()
        {
            new Distribution()
            {
                Name = "EMI",
            },
            new Distribution()
            {
                Name = "Sony",
            },
            new Distribution()
            {
                Name = "Universal",
            },
            new Distribution()
            {
                Name = "Warner",
            },
            new Distribution()
            {
                Name = "e-Muzyka",
            },
            new Distribution()
            {
                Name = "Independent Digital",
            },
        };

        return distributions;
    }
    
    private IEnumerable<User> GetUsers()
    {
        var users = new List<User>()
        {
            new User()
            {
                FirstName = "testName",
                LastName = "testSurname",
                Email = "test@test.pl",
                PasswordHash = "AQAAAAEAACcQAAAAEEcMG4pgYm2rklGBM0CADFBpZiLbsFBsnlFJz10PIPHI5cMIDiCs+8Ap3DkZdUZpRQ==",
                RoleId = 2,
                DistributionId = 3,
            },
        };

        return users;
    }

    private IEnumerable<Album> GetAlbums()
    {
        var albums = new List<Album>()
        {
            new Album()
            {
                Title = "Hotel Maffija",
                Author = "SB Maffija",
                Version = "1.0",
                ReleaseYear = 2020,
                DistributionId = 4,
                Tracks = new List<Track>()
                {
                    new Track()
                    {
                        Title = "Biorę się w garść",
                        Duration = 167,
                        Author = "SBM",
                        ReleaseYear = 2020,
                    }
                }
            },
            new Album()
            {
                Title = "Hotel Maffija 2",
                Author = "SB Maffija",
                Version = "1.1",
                ReleaseYear = 2022,
                DistributionId = 4,
                Tracks = new List<Track>()
                {
                    new Track()
                    {
                        Title = "Lawenda",
                        Duration = 279,
                        Author = "SBM",
                        ReleaseYear = 2022,
                    }
                }
            },
            new Album()
            {
                Title = "Europa",
                Author = "Taco Hemingway",
                Version = "1.1",
                ReleaseYear = 2020,
                DistributionId = 2,
                Tracks = new List<Track>()
                {
                    new Track()
                    {
                        Title = "Luxembourg",
                        Duration = 323,
                        Author = "Taco Hemingway",
                        ReleaseYear = 2020,
                    },
                    new Track()
                    {
                        Title = "Ortalion",
                        Duration = 269,
                        Author = "Taco Hemingway",
                        ReleaseYear = 2020,
                    }
                }
            },
        };

        return albums;
    }
    
}