using MagicFontEnd.Models;
using System.Data.Entity;

namespace MagicApp.Domain
{
    internal class EffectContext : DbContext
    {
        public EffectContext() : base("MySqlDB")
        {

        }


        public DbSet<Effects> Effects { get; set; }



    }
}
