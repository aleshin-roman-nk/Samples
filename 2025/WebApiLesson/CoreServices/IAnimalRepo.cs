using CoreServices.Dto;
using CoreServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreServices
{
	public interface IAnimalRepo
	{
		Task<IEnumerable<Animal>> GetAll();
		Task<Animal> Create(CreateAnimalDto a);
		Task<Animal> Update(UpdateAnimalDto a);
	}
}
