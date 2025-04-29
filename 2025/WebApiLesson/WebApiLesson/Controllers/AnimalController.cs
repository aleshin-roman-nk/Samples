using CoreServices;
using CoreServices.Dto;
using CoreServices.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiLesson.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AnimalController : ControllerBase
	{
		private readonly AnimalService _srv;

		public AnimalController(AnimalService srv)
		{
			_srv = srv;
		}

		[HttpPost]
		public IActionResult Create([FromBody] CreateAnimalDto a)
		{
			return Ok(a);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var r = await _srv.GetAllAsync();
			return  Ok(r);
		}

		[HttpPatch]
		public async Task<IActionResult> UpdateAnimal([FromBody] UpdateAnimalDto a)
		{
			var r = await _srv.UpdateAsync(a);

			return Ok(r);
		}
	}
}
