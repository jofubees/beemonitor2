using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beemonitor2.Models;

namespace Beemonitor2.Data
{
    public class DbInitializer
    {
        public static void Initialize(MonitorContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.SensorTypes.Any())
            {
                return;   // DB has been seeded
            }

            var sensorTypes = new SensorType[]
            {
            new SensorType {TypeDescription="Hive Temperature"},
            new SensorType {TypeDescription="Hive Mass"},
            new SensorType {TypeDescription="Battery Level"},
            new SensorType {TypeDescription="Ambient Temperature"}
            };
            foreach (SensorType s in sensorTypes)
            {
                context.SensorTypes.Add(s);
            }
            context.SaveChanges();

            var apiaries = new Apiary[]
            {
            new Apiary {Name="Test Apiary",Postcode="KT1"}
            };
            foreach (Apiary c in apiaries)
            {
                context.Apiaries.Add(c);
            }
            context.SaveChanges();

            var beehives = new Beehive[]
            {
            new Beehive {Name = "test beehive"}
            };
            foreach (Beehive b in beehives)
            {
                context.Beehives.Add(b);
            }
            context.SaveChanges();
        }
    }
}
