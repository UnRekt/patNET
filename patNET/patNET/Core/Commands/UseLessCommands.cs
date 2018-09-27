using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace patNET.Core.Commands
{
    public class UseLessCommands : ModuleBase<SocketCommandContext>
    {
        [Command("hi"), Alias("hallo", "hey", "hay")]
        public async Task Hello()
        {
            await Context.Channel.SendMessageAsync($"Red mi ned so deppad au, {Context.User.Username}!");
        }

        [Command("du stinkst"), Alias("stinka", "du feist", "stingada")]
        public async Task Stink()
        {
            await Context.Channel.SendMessageAsync($"Des anzige wos do stinkt, is de Solotgurkn dest da vor 2 Minutn ausn Oasch zong host, {Context.User.Username}!");
        }
    }
}
