using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpartanBoosting.Data.Models
{
	public class DiscordReviewsModel
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }

		public static List<DiscordReviewsModel> DiscordInformationList()
		{
			List<DiscordReviewsModel> booster = new List<DiscordReviewsModel>();
			booster.Add(new DiscordReviewsModel { Name = "Dart",  Text = "Plat IV to Diamond IV (the booster was solo playing on the account) : –Good service, the owner was really cool, answered all my questions etc (the booster too) –Went fast and smooth, only one defeat out of like 35-40 games during 4 days (or something around that) –Best price i found So ye i found nothing wrong with them !" });
			booster.Add(new DiscordReviewsModel { Name = "kuddy", Text = "Boost order with | Dan really well done. Got my desired rank in a short period of time, definitely recommend ! " });
			booster.Add(new DiscordReviewsModel { Name = "Wes", Text = "Dan Very legit boosting service. I asked him some questions about diamond 4 to master and he gave me a perfect price I can ’t resist. For me it ’s quiet a bit of money, so he offered a discount to make diamond 4 ->diamond 3 to look if I ’m satisfied about the quality of the boosting. Well goddam!!! I am, first game kassadin 2 penta kills. Second game a quadra kill, and insane amount of kills in diamond level! Just wondering how his guys can get so fast through diamond …Anyway, I will be ordering the master boost soon. Im highly satisfied about his boosting quality ’s + his service. Really friendly guy and keeps you updated on how the order goes. Can only say 100% would recommend!!" });
			booster.Add(new DiscordReviewsModel { Name = "Go B Pls", Text = "Elite Boosting Duo boost and coaching is guaranteed bullet proof. Had an amazing experience and outcomes were beyond what I expected. Learned a lot from just playing in a short period of time with my Duo. Highly Recommended 5 star +++++ This is going to be my go to place for Duo boost + Coaching | Dan For president! " });
			booster.Add(new DiscordReviewsModel { Name = "tsuki117", Text = "Dan honestly one of the best so fast and efficient boosts ive ever had on any game be proud u guys are the only service im gnna use !!! " });
			booster.Add(new DiscordReviewsModel { Name = "Luc", Text = "Ok so my whole journey finished, Hired eliteboosting team to do g1 to p4, then decided to buy p4 to p3, etc up until d4. Everything went smooth, | Dan was super professional, prices were legit and the booster was very helpful &cooperative. GGWP 10/10" });
			booster.Add(new DiscordReviewsModel { Name = "Akogue", Text = "ty very much mate …Glad that i did business with you and honestly best prices and best boosters really helpful guys ….. ty" });
			booster.Add(new DiscordReviewsModel { Name = "Drxgs", Text = " Would highly recommend these guys, quick and good prices! " });
			booster.Add(new DiscordReviewsModel { Name = "Chocco", Text = "This guy is a gem to deal with. Quick boost 0 games lost! Would buy another! " });
			booster.Add(new DiscordReviewsModel { Name = "Jeremy2", Text = "Bought boost from him, one of his booster boosted my acc from g2 31lp to g1 in a day, professional and did great job, I would recommend " });
			return booster;
		}
	}
}
