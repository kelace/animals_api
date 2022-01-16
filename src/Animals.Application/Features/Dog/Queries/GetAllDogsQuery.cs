using Animals.Core;
using Animals.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Animals.Application.Features.Book.Queries
{
    public class GetAllDogsQuery : IRequest<List<Dog>>
    {
        public string Attribute { get; set; }
        public string Order { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllDogsQueryHandler : IRequestHandler<GetAllDogsQuery, List<Dog>>
    {
        private IUnitOfWork _unitOfWork;

        public GetAllDogsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Dog>> Handle(GetAllDogsQuery request, CancellationToken cancellationToken)
        {
            var dogs = await _unitOfWork.Dogs.GetAllAsync(request.Attribute, request.Order.ToUpper(), request.PageNumber, request.PageSize);

            return dogs;
        }
    }

}
