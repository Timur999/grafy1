using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista1zad1
{
    class Edge
    {
        public int Id { get; set; }
        public int Weight {get; set;}
        public int Parent { get; set; }
        public int Child { get; set; }

        public Edge(int p, int c, int w, int id)
        {
            this.Weight = w;
            this.Parent = p;
            this.Child = c;
            this.Id = id;
        }
    }
}
