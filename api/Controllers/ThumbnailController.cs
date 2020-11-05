using System;
using System.Net;
using api.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThumbnailController : Controller
    {
        public ThumbnailController(ILogger<MessagesController> logger)
        {
        }

        [HttpGet]
        public ActionResult GetUrl(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var title = doc.GetTitle();
                var description = doc.GetDescription();
                var thumbnailUrl = doc.GetThumbnailUrl();
                //var thumbnail = new WebClient().DownloadData(thumbnailUrl);

                var element = new ThumbnailData
                {
                    Description = description,
                    Title = title,
                    //Thumbnail = thumbnail
                    ThumbnailUrl = thumbnailUrl
                };

                return Ok(element);
            }
            catch(Exception)
            {
                return Ok(new ThumbnailData());
            }
        }
    }
}