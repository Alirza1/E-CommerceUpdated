using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDapper.DataAccess.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Email;
        }
    }
}
