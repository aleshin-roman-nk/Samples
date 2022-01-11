using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Xorg : ControllerBase
	{
		[HttpGet]
		public string popa()
		{
			return "!!! I AM XORG !!!";
		}

		//[HttpGet]
		//public string Note()
		//{
		//	return "Pay attention!!!";
		//}
	}
}
