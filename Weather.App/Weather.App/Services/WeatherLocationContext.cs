using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Weather.App.Models;
using Xamarin.Essentials;

namespace Weather.App.Services
{
    class WeatherLocationContext : DbContext
    {
        public DbSet<WeatherLocation> WeatherLocations { get; set; }

        public WeatherLocationContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "weatherLocations.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
