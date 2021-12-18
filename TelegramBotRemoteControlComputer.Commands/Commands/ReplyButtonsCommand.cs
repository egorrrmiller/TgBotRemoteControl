using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotRemoteControlComputer.Control.Commands;

public class ReplyButtonsCommand : ICommand
{
    public Task<bool> CanExecute(Update update)
    {
        if(update.CallbackQuery == null)
            return Task.FromResult(update.Message.Text.Contains("/buttons"));

        return Task.FromResult(false);
    }

    public async Task Execute(Update update, ITelegramBotClient client)
    {
        ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
        {
            new KeyboardButton[] {"/start", "/music"}
        })
        {
            ResizeKeyboard = true
        };
        
        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0,
            "Кнопачки", 
            replyMarkup: replyKeyboardMarkup);
    }
}