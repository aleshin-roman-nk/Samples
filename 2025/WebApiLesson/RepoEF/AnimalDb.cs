using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLesson.ImplementRepo.EF.Entities
{
	[Table("animals")]
	public class AnimalDb
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public bool? isBird { get; set; }
	}
}
