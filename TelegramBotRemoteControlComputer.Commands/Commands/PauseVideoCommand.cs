using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Enums;
using WinAPI;

namespace TelegramBotRemoteControlComputer.Control.Commands;

public class PauseVideoCommand : ICommand
{
    public Task<bool> CanExecute(Update update)
    {
        if (update.CallbackQuery != null)
        {
            return Task.FromResult(update.CallbackQuery.Data.Contains(ControlEnum.Pause.ToString()));
        }

        return Task.FromResult(false);
    } 

    public Task Execute(Update update, ITelegramBotClient client)
    {
        MouseKeyboard.PressKey(KeyConstants.VK_SPACE);
        
        return Task.CompletedTask;
    }
}