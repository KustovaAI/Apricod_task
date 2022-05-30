using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using web_C.Models;

namespace web_C.Controllers
{
	[Route("/api/[controller]")]

	
	public class UsersController : Controller
	{
		private RequestsToDb work_with_db = new RequestsToDb();

		[HttpGet("Create")]
		public IActionResult Create(string NameGame, string DeveloperStudio, List<string> Genres)
		{
			(string, Game) res = work_with_db.create(NameGame, DeveloperStudio, Genres);
			if (res.Item1 == "ok")
				return Ok(res.Item2);
			else
			{
				var modelState1 = new ModelStateDictionary();
				modelState1.AddModelError("Error", res.Item1);
				return BadRequest(modelState1);
			}
		}

		[HttpGet("Read")]
		public IEnumerable<Game> Read()
		{
			return work_with_db.read();
		}

		[HttpGet("Update")]
		public IActionResult Update(string NameGame, string DeveloperStudio, List<string> Genres)
		{
			(string, Game) res = work_with_db.update(NameGame, DeveloperStudio, Genres);
			if (res.Item1 == "ok")
				return Ok(res.Item2);
			else
			{
				var modelState1 = new ModelStateDictionary();
				modelState1.AddModelError("Error", res.Item1);
				return BadRequest(modelState1);
			}
		}

		[HttpGet("Delete")]
		public IActionResult Delete(string NameGame)
		{
			(string, Game) res = work_with_db.delete(NameGame);
			if (res.Item1 == "ok")
				return Ok(res.Item2);
			else
			{
				var modelState1 = new ModelStateDictionary();
				modelState1.AddModelError("Error", res.Item1);
				return BadRequest(modelState1);
			}
		}

		[HttpGet("GetGamesCertainGenre")]
		public IEnumerable<Game> GetGamesCertainGenre(string Genre)
		{
			return work_with_db.get_games_by_genre(Genre);
		}
	}
}
