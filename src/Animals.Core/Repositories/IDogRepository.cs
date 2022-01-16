using Animals.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Core.Repositories
{
    public interface IDogRepository
    {
        public Task<Dog> GetByName(string name);
        public Task<List<Dog>> GetAllAsync(string attribute, string order, int pageNumber, int pageSize);
        public Task Create(Dog dog);
    }
}
