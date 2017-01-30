using MagicApp.Domain;
using MtgApiManager.Lib.Model;
using System;
using System.Linq;

namespace MagicApp.Controllers
{
    public class CardController
    {

        //Call to retrieve the solution
        public static Cards RandomSorceryorArtifact()
        {
            using (var ctx = new CardContext())
            {

               
                var selection = ctx.Cards.SqlQuery("Select * from magic.cards where type like '" + "%Artifact%" + "' or type like '" + "%Sorcery%" + "' or type like '" + "%Instant%" + "' order by RAND() limit 1;").ToList();


                return selection.First();

            }

        }


        //Call to retrieve the Problem
        public static Cards Problem()
        {
            using (var ctx = new CardContext())
            {

                var sorcery = ctx.Cards.SqlQuery("Select * from magic.cards where type like '" + "%Creature%" + "' or type like '" + "%Enchantment%" + "' or type like '" + "%conspiracy%" + "' or type like '" + "%Phenomenon%" + "' or type like '" + "%Planeswalker%" + "' or type like '" + "%Vanguard%" + "' order by RAND() limit 1;").ToList();


                return sorcery.First();

            }

        }


        //Call to retrieve the Setting
        public static Cards RandomLand()
        {
            using (var ctx = new CardContext())
            {
               var landlist = ctx.Cards.SqlQuery("Select * from magic.cards where type like '" + "%Land%" + "' or type like '" + "%Plane -%" + "' order by RAND() limit 1;").ToList();

                return landlist.First();

            }

        }
        // Call for antagonist and helper
        public static Cards RandomCreature()
        {
            using (var ctx = new CardContext())
            {
                var creatureList = ctx.Cards.SqlQuery("Select * from magic.cards where type like '" + "%Creature%" + "' or type like '" + "%PlanesWalker%" + "' order by RAND() limit 1;").ToList();


                return creatureList.First();

            }
        }

        
    }
}