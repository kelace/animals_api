using Animals.Application.Features.Book.Commands;
using Animals.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Application.Mappers
{
    public class DogProfile : Profile
    {
        public DogProfile()
        {
            CreateMap<CreateDogCommand, Dog>();
        }
    }
}
