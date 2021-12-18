using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Commands;
using TelegramBotRemoteControlComputer.Control.Enums;
using TelegramBotRemoteControlComputer.Control.Spotify.Service;
using WinAPI;

namespace TelegramBotRemoteControlComputer.Control.Spotify.ControlMusic;

public class ContinueMusicCommand : ICommand
{
    public Task<bool> CanExecute(Update update)
    {
        if (update.CallbackQuery != null)
        {
            return Task.FromResult(update.CallbackQuery.Data.Contains(SpotifyEnum.Continue.ToString()));
        }

        return Task.FromResult(false);
    }

    public async Task Execute(Update update, ITelegramBotClient client)
    {
        ShowSpotifyWindow.BringWindowToFront();
        
        await Task.Delay(350);
        
        MouseKeyboard.PressKey(KeyConstants.VK_SPACE);
        
        await client.EditMessageTextAsync(update?.CallbackQuery?.Message?.Chat.Id,
            update.CallbackQuery.Message.MessageId,
            $"Песня возобновлена...",
            replyMarkup: SpotifyControlKeyboard.SpotifyControlWithPause);
    }
}