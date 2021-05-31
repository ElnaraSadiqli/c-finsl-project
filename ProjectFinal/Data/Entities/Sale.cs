
using ProjectFinal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal.Entities
{    
     public  class Sale : BaseEntite
    {


        public DateTime Date { get; set; }
        public  double Cost { get; set; }

        public List<SalesItem> SalesItems { get; set; }

        private static int _count=0;
       

        public Sale()
        {
            SalesItems = new();
            Date= DateTime.Now;
            _count = No;
        }
       
    }
}

