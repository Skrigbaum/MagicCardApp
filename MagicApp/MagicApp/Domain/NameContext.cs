using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicApp.Domain
{
    internal class NameContext : DbContext
    {
        public NameContext() : base()
       {

       }
        public DbSet<Names> Names { get; set; }
    }
}
