using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfCheckoutSim.Models
{
    public class SelfChecoutSimContext : DbContext
    {
        public SelfChecoutSimContext(Microsoft.EntityFrameworkCore.DbContextOptions<SelfChecoutSimContext> options)
           : base(options)
        { }

        public Microsoft.EntityFrameworkCore.DbSet<Item> Items { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Trans> Orders { get; set; }
    }
}
