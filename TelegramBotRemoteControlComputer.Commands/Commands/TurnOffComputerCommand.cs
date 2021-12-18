﻿using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotRemoteControlComputer.Control.Enums;
using TelegramBotRemoteControlComputer.Control.Models;

namespace TelegramBotRemoteControlComputer.Control.Commands;

public class TurnOffComputerCommand : ICommand
{
    public Task<bool> CanExecute(Update update)
    {
        if (update.CallbackQuery != null)
        {
            return Task.FromResult(update.CallbackQuery.Data.Contains(ControlEnum.TurnOff.ToString()));
        }

        return Task.FromResult(false);
    }

    public async Task Execute(Update update, ITelegramBotClient client)
    {
        for (int i = 3; i > 0; i--)
        {
            await client.EditMessageTextAsync(update?.CallbackQuery?.Message?.Chat.Id,
                update.CallbackQuery.Message.MessageId,
                $"До выключения компьютера {i}...");
           await Task.Delay(1000); 
        }

        await client.EditMessageTextAsync(update?.CallbackQuery?.Message?.Chat.Id,
            update.CallbackQuery.Message.MessageId,
            $"Пульт управления пк",
            replyMarkup: Keyboards.ControlBtn);
        
        /*Process.Start("shutdown","/s /t 0");*/
    }
}