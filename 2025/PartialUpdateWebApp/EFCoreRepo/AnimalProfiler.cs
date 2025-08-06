using AutoMapper;
using EFCoreRepo.entities;
using ServicesCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRepo
{
	public class AnimalProfiler: Profile
	{
		public AnimalProfiler()
		{
			CreateMap<AnimalDb, Animal>().ReverseMap(); // Entity ⇄ Domain
			//CreateMap<Animal, GetAnimalDto>();
			CreateMap<CreateAnimalDto, Animal>();
			CreateMap<UpdateAnimalDto, Animal>();
		}
	}
}
