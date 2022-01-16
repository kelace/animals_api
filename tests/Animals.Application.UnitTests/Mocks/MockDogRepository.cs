using Animals.Core;
using Animals.Core.Entities;
using Animals.Core.Repositories;
using Animals.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests.Animals.Application.UnitTests.Mocks
{
    public static class MockDogRepository
    {
        public static Mock<IUnitOfWork> GetDogRepository()
        {
            var DogList = new List<Dog>
            {
                new Dog
                { Name = "Neo", Color = "red & amber", TailLengt = 22, Weight = 32 },
                new Dog
                { Name = "Jessy", Color = "black & white", TailLengt = 7, Weight = 14 }
             };

            var mockRepo = new Mock<IUnitOfWork>();

            mockRepo.Setup(r => r.Dogs.GetAllAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync((string attribute, string order, int pageNumber, int pageSize) =>
            {
                var getAllQueryCreator = new GetAllQueryCreator();

                var getAllQuery = getAllQueryCreator.Create(attribute, order, pageNumber, pageSize, DogList.AsQueryable());

                return getAllQuery.ToList();
            });

            mockRepo.Setup(r => r.Dogs.Create(It.IsAny<Dog>())).Returns( (Dog dog) => {

                DogList.Add(dog);
                return Task.Run(() => DogList);

            } );

            return mockRepo;

        }
    }
}
