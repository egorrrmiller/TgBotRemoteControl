using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotRemoteControlComputer.Control.Enums;

namespace TelegramBotRemoteControlComputer.Control.Spotify;

public static class SpotifyControlKeyboard
{
    public static InlineKeyboardMarkup SpotifyControlWithPause => new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData("Предыдущая песня", SpotifyEnum.Previous.ToString()), 
            InlineKeyboardButton.WithCallbackData("Следующая песня", SpotifyEnum.Next.ToString())
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData("Пауза", SpotifyEnum.Pause.ToString())
        }
    };
    
    public static InlineKeyboardMarkup SpotifyControlWithContinue => new[]
    {
        new []
        {
            InlineKeyboardButton.WithCallbackData("Предыдущая песня", SpotifyEnum.Previous.ToString()), 
            InlineKeyboardButton.WithCallbackData("Следующая песня", SpotifyEnum.Next.ToString())
        },
        new []
        {
            InlineKeyboardButton.WithCallbackData("Возобновить", SpotifyEnum.Continue.ToString())
        }
    };
}