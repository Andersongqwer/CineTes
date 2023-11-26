using Microsoft.EntityFrameworkCore;
using CineTes.Models;
using System;

namespace CineTes.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Cine> Cines { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) 
            : base(options)
        {

        }

    }
}
