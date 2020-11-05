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
    public class MessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ILogger<MessagesController> logger, ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok("test");
        }

        [HttpGet]
        public ActionResult Get()
        {
            var messages = _context.GetMessages();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var message = _context.GetMessage(id);
            return Ok(message);
        }

        [HttpPost]
        public ActionResult Post(Message message)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(message.Url);
                var thumbnailUrl = doc.GetThumbnailUrl();
                //var thumbnail = new WebClient().DownloadData(thumbnailUrl);
                //message.ImageBytes = thumbnail;
                message.ThumbnailUrl = thumbnailUrl;
            }
            catch (Exception)
            {
                // ignored
            }

            _context.CreateMessage(message);
            return Ok(message);
        }
    }
}