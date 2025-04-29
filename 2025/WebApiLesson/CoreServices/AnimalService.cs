using CoreServices.Dto;
using CoreServices.Entities;

namespace CoreServices
{
	public class AnimalService
	{
		private readonly IAnimalRepo repo;

		public AnimalService(IAnimalRepo repo)
		{
			this.repo = repo;
		}

		public async Task<IEnumerable<Animal>> GetAllAsync()
		{
			return await repo.GetAll();
		}

		public async Task<Animal> Create(CreateAnimalDto a)
		{
			return await repo.Create(a);
		}

		public async Task<Animal> UpdateAsync(UpdateAnimalDto a)
		{
			return await repo.Update(a);
		}
	}
}