using Animals.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Core
{
    public interface IUnitOfWork
    {
        public IDogRepository Dogs { get; set; }
        public  Task<int> SaveAsync();
    }
}
