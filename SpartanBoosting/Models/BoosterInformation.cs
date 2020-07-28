using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Models
{
	public class BoosterInformation
	{
		public string Name { get; set; }
		public string League { get; set; }
		public string Role { get; set; }
		public string Champions { get; set; }
		public string BoosterIcon { get; set; }
		public static List<BoosterInformation> BoosterInformationList()
		{
			List<BoosterInformation> booster = new List<BoosterInformation>();
			booster.Add(new BoosterInformation { Name = "Olin", Champions = "Evelynn", League = "Challenger", Role = "Jungle", BoosterIcon= "Evelynn" });
			booster.Add(new BoosterInformation { Name = "Shank", Champions = "Kindred, Graves, Kha’Zix, Nidalee, Lee Sin, Karthus, Hecarim", League = "Diamond I", Role = "Jungle", BoosterIcon="Graves" });
			booster.Add(new BoosterInformation { Name = "pi6katanamaks", Champions = " Evelynn, Master Yi, Kha’Zix, Draven, Twitch", League = "Master", Role = "ADC / Jungle", BoosterIcon = "Screenshot_5" });
			booster.Add(new BoosterInformation { Name = "Yamy", Champions = "Vlad, Qiyana, Kassadin", League = "Grandmaster", Role = "Mid", BoosterIcon = "Qiyana" });
			booster.Add(new BoosterInformation { Name = "Dread", Champions = "Lulu, Karma, Mundo, Janna, Nautilus, Yuumi", League = "Grandmaster", Role = "Jungle / Support", BoosterIcon = "Lulu" });
			booster.Add(new BoosterInformation { Name = "NPK", Champions = "Kai’Sa, Ezreal, Aphelios, Draven, Graves, Kha’Zix, Hecarim", League = "Grandmaster", Role = "ADC / Jungle", BoosterIcon = "Kaisa" });
			booster.Add(new BoosterInformation { Name = "Cosmic", Champions = "Irelia, Kalista, Twitch, Lucian, Syndra, Graves", League = "Master", Role = "Jungle / Mid / Top", BoosterIcon = "Syndra" });
			booster.Add(new BoosterInformation { Name = "Musti", Champions = "Olaf, Karthus, Mundo, Kindred, Taliyah", League = "Master", Role = "Jungle", BoosterIcon = "Karthus" });
			booster.Add(new BoosterInformation { Name = "Koala", Champions = "Kha’Zix, Lee Sin, Kai’Sa, Sylas, Syndra, Yasuo", League = "Master", Role = "ADC / Jungle / Mid", BoosterIcon = "Koala" });
			booster.Add(new BoosterInformation { Name = "Snowdown", Champions = "Xin Zhao, Rek’sai, Zac, Xayah, Lucian, Caitlyn, Sivir, Vayne", League = "Grandmaster", Role = "ADC / Jungle", BoosterIcon = "Girafarig" });
			booster.Add(new BoosterInformation { Name = "Divine", Champions = "Cassiopeia, Diana, Kassadin", League = "Challenger", Role = "ADC / Mid", BoosterIcon = "Cassiopeia" });
			booster.Add(new BoosterInformation { Name = "Peng", Champions = "Lucian, Aphelios, Kaisa", League = "Grandmaster", Role = "ADC", BoosterIcon = "Aphelios" });
			booster.Add(new BoosterInformation { Name = "Hellman", Champions = "Kaisa, Kalista, Vayne, Aphelios, Cassio, Syndra, Corki", League = "Master", Role = "ADC / Mid", BoosterIcon = "Kaisa" });
			booster.Add(new BoosterInformation { Name = "Garfield", Champions = "All =]", League = "Master", Role = "All =]", BoosterIcon = "Garfield" });
			booster.Add(new BoosterInformation { Name = "Syyron", Champions = "Cassio, Syndra, Orianna, Kalista, Kogmaw, Vayne", League = "Grandmaster", Role = "ADC / MID", BoosterIcon = "Rose" });
			booster.Add(new BoosterInformation { Name = "Feint", Champions = "Riven, Kennen, Kayle, Irelia, Jax, Evelynn, Lee Sin", League = "Grandmaster", Role = "Top / Jungle", BoosterIcon = "Feint" });
			booster.Add(new BoosterInformation { Name = "Blue", Champions = "All =]", League = "Grandmaster", Role = "Support", BoosterIcon = "Thresh" });
			booster.Add(new BoosterInformation { Name = "Gali", Champions = "Galio, Kassadin, Orianna, Syndra, Akali, Leblanc", League = "Grandmaster", Role = "Mid", BoosterIcon = "Orianna" });
			booster.Add(new BoosterInformation { Name = "Reimu", Champions = "Heimerdinger, Darius, Kayn, Yi, Jax, Shyvana, Camille", League = "Grandmaster", Role = "Top / Mid / ADC / Jungle", BoosterIcon = "Heimerdinger" });
			booster.Add(new BoosterInformation { Name = "Lars", Champions = "Evelynn, Volibear, Karthus, Jax", League = "Grandmaster", Role = "Top / Jungle", BoosterIcon = "Evelynn" });

			return booster;
		}
	}
}
