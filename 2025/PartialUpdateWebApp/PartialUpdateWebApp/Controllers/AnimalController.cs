using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesCore;

namespace PartialUpdateWebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnimalController : ControllerBase
	{
		private readonly AnimalService animalService;

		public AnimalController(AnimalService animalService)
		{
			this.animalService = animalService;
		}

		[HttpGet("{id}")] public IActionResult GetAnimal(int id)
		{
			return Ok(animalService.GetAnimal(id));
		}
		[HttpPost] public IActionResult CreateAnimal([FromBody] CreateAnimalDto dto)
		{

		}
	}
}
