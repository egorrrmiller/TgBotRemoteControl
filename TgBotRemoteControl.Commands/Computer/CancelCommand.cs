using System.Diagnostics;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Commands;
using TelegramBotRemoteControlComputer.Control.Enums;
using TelegramBotRemoteControlComputer.Control.Models;

namespace TelegramBotRemoteControlComputer.Control.Computer;

public class CancelCommand : ICommand
{
    public static bool Cancel;
    
    public Task<bool> CanExecute(Update update)
    {
        if (update.CallbackQuery != null)
        {
            return Task.FromResult(update.CallbackQuery.Data.Contains(ControlEnum.Cancel.ToString()));
        }

        return Task.FromResult(false);
    }

    public async Task Execute(Update update, ITelegramBotClient client)
    {
        Cancel = false;
        
        await client.EditMessageTextAsync(update?.CallbackQuery?.Message?.Chat.Id,
            update.CallbackQuery.Message.MessageId,
            "Действие отменено, компьютер будет жить...");

        await Task.Delay(500);
        
        await client.SendTextMessageAsync(update?.CallbackQuery?.Message?.Chat.Id,
            "Пульт управления пк", 
            replyMarkup: Keyboards.ControlBtn);
    }
}