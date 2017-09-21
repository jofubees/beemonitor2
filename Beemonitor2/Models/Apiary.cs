using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beemonitor2.Models
{
    public class Apiary
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }

        public ICollection<Beehive> Beehives { get; set; }
    }
}
