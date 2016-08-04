using System.Data.Entity;

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
