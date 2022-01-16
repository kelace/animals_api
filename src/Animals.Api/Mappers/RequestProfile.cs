using Animals.Api.Requests;
using Animals.Application.Features.Book.Commands;
using Animals.Application.Features.Book.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Api.Mappers
{
    public class RequestProfile : Profile 
    {
        public RequestProfile()
        {
            CreateMap<CreateDogRequest, CreateDogCommand>().ForMember(dest =>
            dest.TailLengt, opt => opt.MapFrom(src => src.tail_length));
        }
    }
}
