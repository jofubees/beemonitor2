using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beemonitor2.Models
{
    public class Observation
    {
        public int Id { get; set; }
        public DateTime ObsDateTime {get; set;}
        public float ObsValue { get; set; }

        public Sensor Sensor { get; set; }
    }
}
