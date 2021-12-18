using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotRemoteControlComputer.Control.Commands;

public interface ICommand
{
    Task<bool> CanExecute(Update update);
    Task Execute(Update update, ITelegramBotClient client);
}