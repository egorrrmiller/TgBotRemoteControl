using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Commands;
using TelegramBotRemoteControlComputer.Control.Models;

namespace TelegramBotRemoteControlComputer.Control.Videos;

public class VideoCommand : ICommand
{
    public Task<bool> CanExecute(Update update)
    {
        if(update.CallbackQuery == null)
            return Task.FromResult(update.Message.Text.Contains("/video"));

        return Task.FromResult(false);
    }

    public async Task Execute(Update update, ITelegramBotClient client)
    {
        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 0,
            "Пульт управления видосиками:", 
            replyMarkup: Keyboards.VideoControlBtn);
    }
}