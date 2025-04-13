using Microsoft.AspNetCore.Mvc;

[Route("api/videos")]
[ApiController]
public class VideoController : ControllerBase
{
    [HttpGet]
    public IActionResult GetYouTubeVideo()
    {
        string videoId = "9cL9eDCkDoQ"; // ID video
        string playlistId = "RDGMEMCMFH2exzjBeE_zAHHJOdxg"; // ID danh sách phát
        string embedUrl = $"https://www.youtube.com/embed/{videoId}?list={playlistId}";
        return Ok(new { Url = embedUrl });
    }
}
