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
            InlineKeyboardButton.WithCallbackData("Отправить в гибернацию", ControlEnum.Hibernate.ToString()), 
        }
    };
    
    public static InlineKeyboardMarkup CancelControlBtn => new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData("Отмена", ControlEnum.Cancel.ToString()), 
        }
    };
    
    public static InlineKeyboardMarkup VideoControlBtn => new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData("Поставить на паузу", VideoEnum.VideoPause.ToString()),
        }
    };
}