using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beemonitor2.Models;
using Microsoft.EntityFrameworkCore;

namespace Beemonitor2.Data
{
    public class MonitorContext : DbContext
    {
        public MonitorContext(DbContextOptions<MonitorContext> options) : base(options)
        {
        }

        public DbSet<Apiary> Apiaries { get; set; }
        public DbSet<Beehive> Beehives { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorType> SensorTypes { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<BeehiveSensor> BeehiveSensors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apiary>().ToTable("Apiaries");
            modelBuilder.Entity<Beehive>().ToTable("Beehives");
            modelBuilder.Entity<Sensor>().ToTable("Sensors");
            modelBuilder.Entity<SensorType>().ToTable("SensorTypes");
            modelBuilder.Entity<Observation>().ToTable("Observations");
            modelBuilder.Entity<BeehiveSensor>().ToTable("BeehiveSensors");

            modelBuilder.Entity<BeehiveSensor>()
                .HasKey(c => new { c.BeehiveId, c.SensorName});
        }

    }
}
