using Animals.Core.Entities;
using Animals.Core.Repositories;
using Animals.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Animals.Infrastructure.Repositories
{
    public class DogRepository : IDogRepository
    {
        private ApplicationDbContext _context;
        public DogRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Dog> GetByName(string name)
        {
            return await _context.Dogs.Where(d => d.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Dog>> GetAllAsync(string attribute, string order, int pageNumber, int pageSize)
        {
            var dogsQueryable = _context.Dogs.AsQueryable();
            var getAllQueryCreator = new GetAllQueryCreator();
            var dogListQueryable = getAllQueryCreator.Create(attribute, order, pageNumber, pageSize, dogsQueryable);
   
            var dogsListResult = await dogListQueryable.ToListAsync();

            return dogsListResult;
        }
        public async Task Create(Dog dog)
        {
            await _context.Dogs.AddAsync(dog);
        }
    }

    public class GetAllQueryCreator {
        public IQueryable<Dog> Create(string attribute, string order, int pageNumber, int pageSize, IQueryable<Dog> dogList)
        {
            var arg = attribute + " " + order.ToUpper();
            var orderResult = dogList.OrderBy(arg);
            var paginationResult = orderResult.Skip(((pageNumber - 1 ) * pageSize));
            var dogsList = pageSize == 0 ? paginationResult : paginationResult.Take(pageSize);

            return dogsList;
        }
    }
 
}
