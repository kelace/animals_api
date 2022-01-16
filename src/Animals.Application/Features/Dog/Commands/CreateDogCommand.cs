using Animals.Core;
using Animals.Core.Entities;
using Animals.Core.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Animals.Application.Features.Book.Commands
{
    public class CreateDogCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLengt { get; set; }
        public int Weight { get; set; }
    }

    public class CreateDogCommandHandler : IRequestHandler<CreateDogCommand, int>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateDogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDogCommand request, CancellationToken cancellationToken)
        {
            var dog = _mapper.Map<Dog>(request);
            await _unitOfWork.Dogs.Create(dog);
            var result = await _unitOfWork.SaveAsync();
            return result;
        }
    }
}
