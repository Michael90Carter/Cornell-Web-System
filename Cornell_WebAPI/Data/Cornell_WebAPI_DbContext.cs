using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cornell_WebAPI.Models;

namespace Cornell_WebAPI.Data
{
    public class Cornell_WebAPI_DbContext : DbContext
    {
        public Cornell_WebAPI_DbContext (DbContextOptions<Cornell_WebAPI_DbContext> options)
            : base(options)
        {
        }

        public DbSet<Cornell_WebAPI.Models.Clientdetails> Clientdetails { get; set; } = default!;

        public DbSet<Cornell_WebAPI.Models.Countriesdetails>? Countriesdetails { get; set; }

        public DbSet<Cornell_WebAPI.Models.Employerdetails>? Employerdetails { get; set; }

        public DbSet<Cornell_WebAPI.Models.Enumeratorsdetails>? Enumeratorsdetails { get; set; }

        public DbSet<Cornell_WebAPI.Models.Jobdetails>? Jobdetails { get; set; }

        public DbSet<Cornell_WebAPI.Models.Placementdetails>? Placementdetails { get; set; }
    }
}
