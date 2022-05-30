using System;
using System.Collections.Generic;
using System.Linq;
using web_C.Models;

namespace web_C
{
	public class RequestsToDb
	{
		public (string, Game) create(string NameGame, string DeveloperStudio, List<string> Genres)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				Game new_game = new Game { Name = NameGame, DeveloperStudio = DeveloperStudio, Genres = Genres };
				db.Games.AddRange(new_game);
				try
				{
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					return (ex.Message, null);
				}
				return ("ok", new_game);
			}
		}
		public IEnumerable<Game> read()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var games = db.Games.ToList();
				return games;
			}
		}
		public (string, Game) update(string NameGame, string DeveloperStudio, List<string> Genres)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var game = db.Games.SingleOrDefault(b => b.Name == NameGame);
				if (game != null)
				{
					game.DeveloperStudio = DeveloperStudio;
					game.Genres = Genres;
					try
					{
						db.SaveChanges();
					}
					catch (Exception ex)
					{
						return (ex.Message, null);
					}
				}
				else
				{
					return ("There is no game with such name", null);
				}
				return ("ok", game);
			}
		}

		public (string, Game) delete(string NameGame)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var game = db.Games.SingleOrDefault(b => b.Name == NameGame);
				if (game != null)
				{
					db.Games.Remove(game);
					try
					{
						db.SaveChanges();
					}
					catch (Exception ex)
					{
						return (ex.Message, null);
					}
				}
				else
				{
					return ("There is no game with such name", null);
				}
				return ("ok", game);
			}
		}

		public IEnumerable<Game> get_games_by_genre(string Genre)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var games = db.Games.Where(p => p.Genres.Contains(Genre)).ToList();
				return games;
			}
		}
	}
}

