using AutoMapper;
using CoreServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLesson.ImplementRepo.EF.Entities;

namespace WebApiLesson.ImplementRepo.EF.MappingProfiles
{
	public class AnimalProfile : Profile
	{
		public AnimalProfile()
		{
			CreateMap<UpdateAnimalDto, AnimalDb>()
				.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
}
