using Animals.Api.Requests;
using Animals.Application.Features.Book.Commands;
using Animals.Application.Features.Book.Queries;
using Animals.Core;
using Animals.Core.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Api.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IMediator _mediator;
        private IMapper _mapper;
        public HomeController(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
        {
             _unitOfWork = unitOfWork;
             _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("/ping")]
        public IActionResult Ping()
        {
            return Ok("Dogs house service. Version 1.0.1");
        }

        [HttpGet]
        [Route("/dogs")]
        public async Task<IActionResult> Dogs([FromQuery]GetAllDogsQuery cmd)
        {
            if (cmd.Attribute == null)
            {
                cmd.Attribute = "Name";
            }

            if (cmd.Order == null || (cmd.Order.ToUpper() != "DESC" && cmd.Order.ToUpper() != "ASC"))
            {
                cmd.Order = "DESC";
            }

            var dogs = await _mediator.Send(cmd);

            return Ok(dogs);
        }

        [HttpPost]
        [Route("/dog")]
        public async Task<IActionResult> Dog(CreateDogRequest request)
        {
            var dogResult = _unitOfWork.Dogs.GetByName(request.name);

            if(dogResult != null)
            {
                BadRequest("Dog has already registered");
            }

            if (request.name == null)
            {
                BadRequest("Dog has no name");
            }

            if (request.weight <= 0)
            {
                BadRequest("Dog has no weight");
            }

            if (request.tail_length == null)
            {
                BadRequest("Dog has no tail length");
            }
            var cmd = _mapper.Map<CreateDogCommand>(request);
            var result = await _mediator.Send(cmd);

            if (result != 1)
            {
                BadRequest("Cannot create new dog");
            }

            return Ok("Dog has been registered");
        }
    }
}
