using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicApp.Domain
{
   internal class CardContext : DbContext
    {
       public CardContext() : base()
       {
           
       }


       public DbSet<Cards> Cards { get; set; }
    

    }
}
