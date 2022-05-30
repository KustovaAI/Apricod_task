using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_C.Models
{
	[Table("games")]
	public class Game
	{
		[Key]
		[Column("name")]
		public string Name { get; set; }

		[Column("developer_studio")]
		public string DeveloperStudio { get; set; }

		[Column("genres")]
		public List<string> Genres { get; set; }
	}
}
