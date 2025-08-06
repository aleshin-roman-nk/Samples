using EFCoreRepo;
using ServicesCore.Entities;
using ServicesCore.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesCore
{
	public class AnimalService
	{
		private readonly IAnimalRepo animalRepo;

		public AnimalService(IAnimalRepo animalRepo)
		{
			this.animalRepo = animalRepo;
		}

		//public async Task<IEnumerable<Animal>> GetAnimals()
		//{
		//	return await 
		//}

		public Animal GetAnimal(int id)
		{
			return new Animal { id = id, name = "Barsik" };
		}


	}
}
