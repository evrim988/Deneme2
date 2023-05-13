using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Domain.Common
{
    public class Costumer:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CostumerID { get; set; }
    }
}
