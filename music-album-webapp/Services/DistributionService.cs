using music_album_webapp.Entities;

namespace music_album_webapp.Services;

public interface IDistributionService
{
    IEnumerable<Distribution> GetDistributions();
}

public class DistributionService : IDistributionService
{
    private readonly DataContext _dataContext;

    public DistributionService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public IEnumerable<Distribution> GetDistributions()
    {
        var distributions = _dataContext.Distributions;

        return distributions;
    }
}