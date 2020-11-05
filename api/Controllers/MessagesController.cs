using api.Models;
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
            _context.CreateMessage(message);
            return Ok(message);
        }
    }
}