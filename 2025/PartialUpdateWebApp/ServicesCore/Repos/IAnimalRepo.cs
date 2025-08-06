using ServicesCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesCore.Repos
{
	public interface IAnimalRepo
	{
		Task<IEnumerable<Animal>> GetAnimalsAsync();
		Task<Animal> CreateAnimalAsync(CreateAnimalDto animal);
		Task<Animal> UpdateAnimalAsync(int id, UpdateAnimalDto animal);
	}
}
