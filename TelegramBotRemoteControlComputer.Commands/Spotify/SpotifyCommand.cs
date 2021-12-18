using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Commands;
using TelegramBotRemoteControlComputer.Control.Spotify.Service;
using WinAPI;

namespace TelegramBotRemoteControlComputer.Control.Spotify;

public class SpotifyCommand : ICommand
{
    public Task<bool> CanExecute(Update update)
    {
        if(update.CallbackQuery == null)
            return Task.FromResult(update.Message.Text.Contains("/music"));

        return Task.FromResult(false);
    }

    public async Task Execute(Update update, ITelegramBotClient client)
    {
        ShowSpotifyWindow.BringWindowToFront();
        
        await Task.Delay(350);
        
        MouseKeyboard.PressKey(KeyConstants.VK_SPACE);
        
        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0,
            "Музыка включена. \nПульт управления музыкой:", 
            replyMarkup: SpotifyControlKeyboard.SpotifyControlWithPause);
    }
}