using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapiexamp.data;

namespace webapiexamp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ComputersController : ControllerBase
	{
		private readonly ComputersRepo _repo;

		//ComputersRepo
		public ComputersController(ComputersRepo repo)
		{
			_repo = repo;
		}


		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_repo.GetAll());
		}
	}
}
