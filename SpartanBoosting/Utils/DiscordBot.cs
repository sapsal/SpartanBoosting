using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Utils
{
	public class DiscordBot
	{
		public DiscordClient client { get; private set; }
		public CommandsNextExtension commands { get; private set; }
		public async Task RunAsync(Models.Pricing.PurchaseForm model)
		{
			var config = new DiscordConfiguration
			{
				Token = "NzM5OTU4MjcwMDIxNTk5Mjc0.XyiB1w.M_2CJkUzPa8bP63z_mBEk_mpY8w",
				TokenType = TokenType.Bot,
				AutoReconnect = true,
				LogLevel = LogLevel.Debug,
				UseInternalLogHandler = true
			};
			client = new DiscordClient(config);
			client.Ready += OnClientReady;

			var commandsConfig = new CommandsNextConfiguration
			{
				StringPrefixes = new string[] { "?" },
				EnableMentionPrefix = true,
				EnableDms = false
			};

			commands = client.UseCommandsNext(commandsConfig);
			await client.ConnectAsync();
			var channel = await client.GetChannelAsync(739974111455084675);
			//await client.SendMessageAsync(channel, SoloDiscordMessage(model));
		}

		//public string SoloDiscordMessage(Models.Pricing.PurchaseForm model)
		//{
		//	//return "**New Division Solo**\n\n" +
		//	//		"**Id : #LOL-TEST**\n\n" +
		//	//		"__**BOOST DETAILS:**__\n\n\n\n" +
		//	//		"**Current Rank**                   **Desired Rank**" +
		//	//		$"{model.CurrentDivision}";

		//	return "**New Division Solo**\n\n" +
		//			$"**Job : {model.YourCurrentLeague} {model.CurrentDivision} {model.CurrentLP} to {model.DesiredCurrentLeague} {model.DesiredCurrentDivision}**\n\n" +
		//			$"**Queue : {model.TypeOfQueue}**\n\n" +
		//			$"**Server : {model.Server}**\n\n" +
		//			$"**Price : €{model.Price}**";
		//}

		private Task OnClientReady(ReadyEventArgs e)
		{
			return Task.CompletedTask;
		}
	}
}
