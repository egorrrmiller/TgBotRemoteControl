using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Models;

namespace TelegramBotRemoteControlComputer.Control.Commands;

public class StartCommand : ICommand
{
    public Task<bool> CanExecute(Update update)
    {
        if(update.CallbackQuery == null)
            return Task.FromResult(update.Message.Text.Contains("/start"));

        return Task.FromResult(false);
    }

    public async Task Execute(Update update, ITelegramBotClient client)
    {
        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0,
            "Пульт управления пк", 
            replyMarkup: Keyboards.ControlBtn);
    }
}