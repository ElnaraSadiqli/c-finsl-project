using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Entities
{
    public class SalesItem :BaseEntite
    {    

        public Product Product { get; set; }
        public double Cost { get; set; } 
        public int Amount { get; set; }

        private static int _count = 0;
      
    public SalesItem()

    {
           
       _count++;
       No = _count;
    }



    }
    
}
