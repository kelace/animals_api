using Animals.Core;
using Animals.Core.Repositories;
using Animals.Infrastructure.Data;
using Animals.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDogRepository Dogs {get; set;}
        private ApplicationDbContext _db {get; set;}

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Dogs = new DogRepository(_db);
        }
        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
