namespace CoreServices.Dto
{
	public class UpdateAnimalDto : IUpdatableEntityDto
	{
		public int id { get; set; }
		public string? name { get; set; }
		public string? description { get; set; }
		public bool? isBird { get; set; }
	}
}
