using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace patNET.Core.Commands
{
    public class NewUsers : ModuleBase<SocketCommandContext>
    {
        [Command("akzeptieren")]
        public async Task Akzeptieren()
        {
            var role = (Context.User as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "Mitglied");
            await Context.Channel.SendMessageAsync("Gleich wirst du Zugriff bekommen!");
            var message = await Context.Channel.GetMessagesAsync(2).Flatten();
            await ((ITextChannel)Context.Channel).DeleteMessagesAsync(message);
            await (Context.User as IGuildUser).AddRoleAsync(role);
        }

        [Command("clean")]
        public async Task CleanChat(int amount)
        {
            var role = (Context.User as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "Admin");
            if ((Context.User as IGuildUser).Guild.Roles.Contains(role))
            {
                var messages = await Context.Channel.GetMessagesAsync(amount + 1).Flatten();
                await ((ITextChannel)Context.Channel).DeleteMessagesAsync(messages);
            }
        }
    }
}
