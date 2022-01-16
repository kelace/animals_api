using Animals.Application.Features.Book.Queries;
using Animals.Core;
using Animals.Core.Entities;
using Animals.Core.Repositories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tests.Animals.Application.UnitTests.Mocks;
using Xunit;

namespace Tests.Animals.Application.UnitTests.Queries
{
    public class GetAllDogsQueryHanlderTest
    {
        private Mock<IUnitOfWork> _mockRepo;

        public GetAllDogsQueryHanlderTest()
        {
            _mockRepo = MockDogRepository.GetDogRepository();
        }

        [Fact]
        public async Task GetAllDogsQueryHanlder()
        {
            var handler = new GetAllDogsQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new GetAllDogsQuery{ Attribute = "Name", Order = "DESC", PageNumber = 0, PageSize = 0 }, CancellationToken.None);

            result[0].Name.ShouldBe("Neo");
        }
    }
}
