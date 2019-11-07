using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciarProcessos.Models;

namespace GerenciarProcessos.Models
{
    public class GerenciarProcessosContext : DbContext
    {
        public GerenciarProcessosContext (DbContextOptions<GerenciarProcessosContext> options)
            : base(options)
        {
        }

        public DbSet<GerenciarProcessos.Models.Cliente> Cliente { get; set; }

        public DbSet<GerenciarProcessos.Models.Processo> Processo { get; set; }
    }
}
