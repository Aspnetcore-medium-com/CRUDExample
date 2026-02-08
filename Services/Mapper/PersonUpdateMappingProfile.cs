using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class PersonUpdateMappingProfile : Profile
    {
        public PersonUpdateMappingProfile()
        {
            CreateMap<ServiceContracts.DTO.PersonUpdateRequest, Entities.Person>();
            CreateMap<Entities.Person, ServiceContracts.DTO.PersonResponse>();
        }
    }
}
