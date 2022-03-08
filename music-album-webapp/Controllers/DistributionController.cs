using Microsoft.AspNetCore.Mvc;
using music_album_webapp.Entities;
using music_album_webapp.Services;

namespace music_album_webapp.Controllers;

[ApiController]
[Route("api/distributions")]
public class DistributionController : ControllerBase
{
    private readonly IDistributionService _distributionService;

    public DistributionController(IDistributionService distributionService)
    {
        _distributionService = distributionService;
    }

    [HttpGet]
    public ActionResult<Distribution> Get()
    {
        var results = _distributionService.GetDistributions();

        return Ok(results);
    }
}