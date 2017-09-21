using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beemonitor2.Models
{
    public class Beehive
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<BeehiveSensor> BeehiveSensors { get; set; }
        public Apiary Apiary { get; set; }
    }
}
