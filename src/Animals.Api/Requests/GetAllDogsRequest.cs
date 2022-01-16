using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animals.Api.Requests
{
    public class CreateDogRequest
    {
        public string name { get; set; }
        public string color { get; set; }
        public int tail_length { get; set; }
        public int weight { get; set; }
    }
}
