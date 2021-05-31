
using ProjectFinal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Entities
{
    public  class Product :BaseEntite
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public  Categories Category { get; set; }

        private static int _count = 0;


        public Product()
        {

            _count++;
            No = _count;


        }

       
    }
}

 
 
 