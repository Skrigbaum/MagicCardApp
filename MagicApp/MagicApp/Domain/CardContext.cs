using System.Data.Entity;

namespace MagicApp.Domain
{
    internal class CardContext : DbContext
    {
       public CardContext() : base("MySqlDB")
       {
           
       }


       public DbSet<Cards> Cards { get; set; }

        

    }
}
