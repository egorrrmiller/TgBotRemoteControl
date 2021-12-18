using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Commands;

namespace TelegramBotRemoteControlComputer.Processor;

public class ProcessingEvents
{
    private readonly ITelegramBotClient _client;
    private readonly IEnumerable<ICommand> _commands;

    private const int OwnerId = 694021983;

    public ProcessingEvents(IEnumerable<ICommand> commands, ITelegramBotClient client)
    {
        _commands = commands;
        _client = client;
    }

    public Task Processing(Update update)
    {
        try
        {
            if (update.CallbackQuery?.From.Id == OwnerId || update.Message?.From?.Id == OwnerId)
                _commands.FirstOrDefault(cmd => cmd.CanExecute(update).Result)?.Execute(update, _client);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return Task.CompletedTask;
    }
}