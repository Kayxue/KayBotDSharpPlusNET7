using DSharpPlus;
using DSharpPlus.CommandsNext;
using KayBotDSharpPlus2._0;
using KayBotDSharpPlus2._0.Commands;
using Microsoft.Extensions.Logging;

DiscordClient? client;
DiscordIntents intents = DiscordIntents.All;
CommandsNextExtension BotCommand;

DiscordConfiguration configuration = new DiscordConfiguration
{
    Token = Config.TOKEN,
    TokenType = TokenType.Bot,
    AutoReconnect = true,
    MinimumLogLevel = LogLevel.Debug,
    Intents = intents
};

CommandsNextConfiguration commandsNextConfiguration = new CommandsNextConfiguration
{
    CaseSensitive = true,
    StringPrefixes = new[] { "t!" },
    EnableMentionPrefix = true,
    EnableDefaultHelp = false,
};

client = new DiscordClient(configuration);
client.Ready += (discordClient, args) =>
{
    discordClient.Logger.LogInformation(
        "機器人已上線",
        DateTime.Now
    );

    return Task.CompletedTask;
};

BotCommand = client.UseCommandsNext(commandsNextConfiguration);

BotCommand.RegisterCommands<Info>();

BotCommand.CommandExecuted += (extension, args) =>
{
    extension.Client.Logger.LogInformation(
        $"{args.Context.User.Username}使用了指令{args.Command.QualifiedName}",
        DateTime.Now
    );
    return Task.CompletedTask;
};

BotCommand.CommandErrored += (extension, args) =>
{
    try
    {
        extension.Client.Logger.LogError(
            $"指令{args.Command.Name}發生錯誤！錯誤原因：{args.Exception.Message}",
            DateTime.Now
        );
    }
    catch (Exception e)
    {
        extension.Client.Logger.LogError(
            $"發生錯誤！錯誤原因：{args.Exception.Message}",
            DateTime.Now
        );
    }

    return Task.CompletedTask;
};

await client.ConnectAsync();
await Task.Delay(-1);


