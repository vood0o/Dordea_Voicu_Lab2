﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dordea_Voicu_Lab2.Models;

namespace Dordea_Voicu_Lab2.Data
{
    public class Dordea_Voicu_Lab2Context : DbContext
    {
        protected readonly IConfiguration Configuration;

        public Dordea_Voicu_Lab2Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("Dordea_Voicu_Lab2Context"));
        }

        public DbSet<Dordea_Voicu_Lab2.Models.Book> Book { get; set; }
    }
}