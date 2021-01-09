using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using SpartanBoosting.Extensions;
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
			var channel = await client.GetChannelAsync(753571987825360998);
			await client.SendMessageAsync(channel, DiscordMessage(model));
		}

		public string DiscordMessage(Models.Pricing.PurchaseForm Model)
		{
			switch (Model.PurchaseType)
			{
				case PurchaseTypeEnum.PurchaseType.SoloBoosting:
					return DiscordServerTagMessage(Model.BoostingModel.Server) + "**New Division Solo**\n" +
							$"**Job : { Model.BoostingModel.YourCurrentLeague}{ Model.BoostingModel.CurrentDivision} { Model.BoostingModel.CurrentLP} to { Model.BoostingModel.DesiredCurrentLeague} { Model.BoostingModel.DesiredCurrentDivision}**\n" +
							$"**Queue : {Model.BoostingModel.TypeOfQueue}**\n" +
							$"**Server : {Model.BoostingModel.Server}**\n" +
							$"**Price : €{LolPricingExtensions.BoosterPay(Model)}**";
				case PurchaseTypeEnum.PurchaseType.DuoBoosting:
					return DiscordServerTagMessage(Model.BoostingModel.Server) + "**New Division Duo**\n" +
							$"**Job : { Model.BoostingModel.YourCurrentLeague}{ Model.BoostingModel.CurrentDivision} { Model.BoostingModel.CurrentLP} to { Model.BoostingModel.DesiredCurrentLeague} { Model.BoostingModel.DesiredCurrentDivision}**\n" +
							$"**Queue : {Model.BoostingModel.TypeOfQueue}**\n" +
							$"**Server : {Model.BoostingModel.Server}**\n" +
							$"**Type : {(Model.BoostingModel.TypeOfDuoRegular != "false" ? Model.BoostingModel.TypeOfDuoRegular : Model.BoostingModel.TypeOfDuoPremium)}**\n" +
							$"**Price : €{LolPricingExtensions.BoosterPay(Model)}**";
				case PurchaseTypeEnum.PurchaseType.WinBoosting:
					if (Model.WinBoostModel.TypeOfService == "Duo")
						return DiscordServerTagMessage(Model.WinBoostModel.Server) + "**Win Boosting**\n" +
							$"**Job : {Model.WinBoostModel.YourCurrentLeague} {Model.WinBoostModel.CurrentDivision} with {Model.WinBoostModel.NumOfGames} games**\n" +
							$"**Queue : {Model.WinBoostModel.TypeOfQueue}**\n" +
							$"**Server : {Model.WinBoostModel.Server}**\n" +
							$"**Type : Duo {(Model.WinBoostModel.TypeOfDuoRegular != "false" ? Model.WinBoostModel.TypeOfDuoRegular : Model.WinBoostModel.TypeOfDuoPremium)}**\n" +
							$"**Price : €{LolPricingExtensions.BoosterPay(Model)}**";
					else
						return DiscordServerTagMessage(Model.WinBoostModel.Server) + $"**Job : {Model.WinBoostModel.YourCurrentLeague} {Model.WinBoostModel.CurrentDivision} with {Model.WinBoostModel.NumOfGames} games**\n" +
								$"**Queue : {Model.WinBoostModel.TypeOfQueue}**\n" +
								$"**Server : {Model.WinBoostModel.Server}**\n" +
								$"**Type : Solo**\n" +
								$"**Price : €{LolPricingExtensions.BoosterPay(Model)}**";
				case PurchaseTypeEnum.PurchaseType.PlacementMatches:
					if (Model.PlacementMatchesModel.TypeOfService == "Duo")
						return DiscordServerTagMessage(Model.PlacementMatchesModel.Server) + "**Placement Matches**\n" +
								$"**Job : {Model.PlacementMatchesModel.LastSeasonStanding} with {Model.PlacementMatchesModel.NumOfGames} games**\n" +
								$"**Queue : {Model.PlacementMatchesModel.TypeOfQueue}**\n" +
								$"**Server : {Model.PlacementMatchesModel.Server}**\n" +
								$"**Type : Duo {(Model.PlacementMatchesModel.TypeOfDuoRegular != "false" ? Model.PlacementMatchesModel.TypeOfDuoRegular : Model.PlacementMatchesModel.TypeOfDuoPremium)}**\n" +
								$"**Price : €{LolPricingExtensions.BoosterPay(Model)}**";
					else
						return DiscordServerTagMessage(Model.PlacementMatchesModel.Server) + $"**Placement Matches {Model.PlacementMatchesModel.TypeOfService}**\n" +
								$"**Job : {Model.PlacementMatchesModel.LastSeasonStanding} with {Model.PlacementMatchesModel.NumOfGames} games**\n" +
								$"**Queue : {Model.PlacementMatchesModel.TypeOfQueue}**\n" +
								$"**Server : {Model.PlacementMatchesModel.Server}**\n" +
								$"**Type : Solo**\n" +
								$"**Price : €{LolPricingExtensions.BoosterPay(Model)}**";

				case PurchaseTypeEnum.PurchaseType.TFTPlacement:
					return DiscordServerTagMessage(Model.TFTPlacementModel.Server) + "**TFT Placement**\n" +
							$"**Job : {Model.TFTPlacementModel.LastSeasonStanding} with {Model.TFTPlacementModel.NumberOfGames} games**\n" +
							$"**Server : {Model.TFTPlacementModel.Server}**\n" +
							$"**Price : €{LolPricingExtensions.BoosterPay(Model)}**";
				case PurchaseTypeEnum.PurchaseType.TFTBoosting:
					return DiscordServerTagMessage(Model.TFTBoostingModel.Server) + "**TFT Solo Boosting**\n" +
							$"**Job : {Model.TFTBoostingModel.YourCurrentLeague} {Model.TFTBoostingModel.CurrentDivision} {Model.TFTBoostingModel.CurrentLP} to {Model.TFTBoostingModel.DesiredCurrentLeague} {Model.TFTBoostingModel.DesiredCurrentDivision}**\n" +
							$"**Server : {Model.TFTBoostingModel.Server}**\n" +
							$"**Price : €{LolPricingExtensions.BoosterPay(Model)}**";

				case PurchaseTypeEnum.PurchaseType.Coaching:
					break;
				default:
					break;
			}
			return "";
		}

		public string DiscordServerTagMessage(string Server)
		{
			string NATag = "<@&718007652675747865>\n";
			string EUTag = "<@&718007613115072534>\n";

			if (Server == "Europe West" || Server == "Europe Nordic &amp; East" || Server == "Russia" || Server == "Turkey")
			{
				//EU TAG
				return EUTag;
			}
			else if (Server == "North America" || Server == "Oceania" || Server == "Latin America North" || Server == "Latin America South" || Server == "Brazil")
			{
				//NA Tag
				return NATag;
			}
			return "";
		}

		private Task OnClientReady(ReadyEventArgs e)
		{
			return Task.CompletedTask;
		}
	}
}
