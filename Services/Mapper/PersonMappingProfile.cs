using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class PersonMappingProfile: Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<ServiceContracts.DTO.PersonAddRequest, Entities.Person>()
                .ForMember(dest => dest.PersonId, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.HasValue ? src.Gender.Value.ToString() : null));
           
            CreateMap<Entities.Person, ServiceContracts.DTO.PersonResponse>();
        }
    }
}
