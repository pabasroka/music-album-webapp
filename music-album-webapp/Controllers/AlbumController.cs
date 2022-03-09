using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using music_album_webapp.Models;
using music_album_webapp.Services;

namespace music_album_webapp.Controllers;

[ApiController]
[Route("api/albums")]
public class AlbumController : ControllerBase
{
    private readonly IAlbumService _albumService;

    public AlbumController(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet]
    [Authorize(Policy = "DistributionPolicy")]
    public ActionResult<IEnumerable<AlbumDto>> GetAll([FromQuery] AlbumQuery query)
    {
        var results = _albumService.GetAll(query);

        return Ok(results);
    }

}