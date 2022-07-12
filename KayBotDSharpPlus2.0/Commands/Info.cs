using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace KayBotDSharpPlus2._0.Commands;

public class Info:BaseCommandModule
{
    [Command("test")]
    public async Task testCommand(CommandContext ctx)
    {
        await ctx.RespondAsync("test");
    }

    [Command("ping")]
    public async Task pingCommand(CommandContext ctx)
    {
        await ctx.RespondAsync($"Ping: {ctx.Client.Ping.ToString()}ms");
    }
}