using AutoMapper;
using EFCoreRepo.entities;
using Microsoft.EntityFrameworkCore;
using ServicesCore.Entities;
using ServicesCore.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRepo
{
	public class AnimalRepo : IAnimalRepo
	{
		private readonly AppData appData;
		private readonly IMapper mapper;

		public AnimalRepo(AppData appData, IMapper mapper)
		{
			this.appData = appData;
			this.mapper = mapper;
		}

		public Task<Animal> CreateAnimalAsync(CreateAnimalDto animal)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Animal>> GetAnimalsAsync()
		{
			return await appData.Animals
								.Select(db => new Animal
								{
									id = db.id,
									name = db.name,
									age = db.age,
									description = db.description,
									isFlying = db.isFlying
								})
								.ToListAsync();
		}

		public Task<Animal> UpdateAnimalAsync(int id, UpdateAnimalDto animal)
		{
			throw new NotImplementedException();
		}
	}
}
