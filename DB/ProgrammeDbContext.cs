using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace simple_crud.DB
{
    public class ProgrammeDbContext : DbContext
    {
        public ProgrammeDbContext(DbContextOptions<ProgrammeDbContext> option) : base(option)
        {

        }

        public DbSet<Programme> Programmes { get; set; }
    }
}