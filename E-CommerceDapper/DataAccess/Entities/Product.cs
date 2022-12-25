using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapper.DataAccess.Entities
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public Decimal UnitPrice { get; set; }

        public short UnitsInStock { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return ProductName;
        }

    }
}
