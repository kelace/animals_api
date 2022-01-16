using Animals.Application.Features.Book.Commands;
using Animals.Application.Features.Book.Queries;
using Animals.Core;
using Animals.Core.Entities;
using AutoMapper;
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

namespace Animals.Application.UnitTests.Commands
{
    public class CreateDogCommandHanlderTest
    {
        private Mock<IUnitOfWork> _mockRepo;

        public CreateDogCommandHanlderTest()
        {
            _mockRepo = MockDogRepository.GetDogRepository();
        }

        [Fact]
        public async Task CreateDogCommandTest()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateDogCommand, Dog>());
            var mapper = config.CreateMapper();
            var handler = new CreateDogCommandHandler(_mockRepo.Object, mapper);

            var request = new CreateDogCommand { Name = "box", Color = "black", TailLengt = 5, Weight = 24 };

            var result = handler.Handle(request, CancellationToken.None);

            var getHandler = new GetAllDogsQueryHandler(_mockRepo.Object);
            var dogs = await getHandler.Handle(new GetAllDogsQuery { Attribute = "Name", Order = "DESC", PageNumber = 0, PageSize = 0 }, CancellationToken.None);

            dogs.Count.ShouldBe(3);
            dogs[2].Name.ShouldBe("box");
            dogs[2].Color.ShouldBe("black");
            dogs[2].TailLengt.ShouldBe(5);
            dogs[2].Weight.ShouldBe(24);
        }
    }
}
