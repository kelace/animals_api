using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Core.Entities
{
    public class Dog
    {
        public string Id { get; set; }
        public string Name {get; set;}
        public string Color { get; set; }
        public int TailLengt { get; set; }
        public int Weight { get; set; }


        public Dog()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
