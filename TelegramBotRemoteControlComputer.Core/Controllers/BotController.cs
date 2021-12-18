using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Processor;

namespace TelegramBotRemoteControlComputer.Controllers
{
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly ProcessingEvents _processingEvents;

        public BotController(ProcessingEvents processingEvents)
        {
            _processingEvents = processingEvents;
        }

        [HttpPost]
        [Route("/api/bot")]
        public async Task<IActionResult> Handle([FromBody] Update update)
        {
            await _processingEvents.Processing(update);
            
            return Ok();
        }
    }
}