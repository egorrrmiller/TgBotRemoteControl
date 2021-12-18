using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotRemoteControlComputer.Control.Enums;

namespace TelegramBotRemoteControlComputer.Control.Models;

public class Keyboards
{
    public static InlineKeyboardMarkup ControlBtn => new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData("Выключить пк", ControlEnum.TurnOff.ToString()), 
            
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData("Нажать пробел", ControlEnum.Pause.ToString())
        }
    };
}