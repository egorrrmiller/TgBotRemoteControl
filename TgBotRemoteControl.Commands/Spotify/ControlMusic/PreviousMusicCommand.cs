using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Commands;
using TelegramBotRemoteControlComputer.Control.Enums;
using TelegramBotRemoteControlComputer.Control.Spotify.Service;
using WinAPI;

namespace TelegramBotRemoteControlComputer.Control.Spotify.ControlMusic;

public class PreviousMusicCommand : ICommand
{
    public Task<bool> CanExecute(Update update)
    {
        if(update.CallbackQuery != null)
            return Task.FromResult(update.CallbackQuery.Data.Contains(SpotifyEnum.Previous.ToString()));

        return Task.FromResult(false);
    }

    public async Task Execute(Update update, ITelegramBotClient client)
    {
        ShowSpotifyWindow.BringWindowToFront();
        
        await Task.Delay(350);
        
        MouseKeyboard.PressKey(KeyConstants.VK_LEFT, false, false, true);
        
        await client.EditMessageTextAsync(update?.CallbackQuery?.Message?.Chat.Id,
            update.CallbackQuery.Message.MessageId,
            $"Включаю предыдущую песню...",
            replyMarkup: SpotifyControlKeyboard.SpotifyControlWithPause);
    }
}