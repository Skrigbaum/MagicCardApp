using MagicApp.Domain;
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

                var selection = ctx.Cards.Where(t => t.Type.Contains("Artifact") || t.Type.Contains("Sorcery") || t.Type.Contains("Instant")).OrderBy(r => Guid.NewGuid()).Take(1);


                return selection.First();

            }

        }


        //Call to retrieve the Problem
        public static Cards Problem()
        {
            using (var ctx = new CardContext())
            {

                var sorcery = ctx.Cards.Where(s => s.Type.Contains("Creature") || s.Type.Contains("Enchantment") || s.Type.Contains("Conspiracy") || s.Type.Contains("Scheme") || s.Type.Contains("Phenomenon") || s.Type.Contains("PlanesWalker") || s.Type.Contains("Vanguard")).OrderBy(r => Guid.NewGuid()).Take(1);


                return sorcery.First();

            }

        }


        //Call to retrieve the Setting
        public static Cards RandomLand()
        {
            using (var ctx = new CardContext())
            {
                var landlist = ctx.Cards.Where(l => l.Type.Contains("land") || l.Type.Contains("Plane -")).OrderBy(r => Guid.NewGuid()).Take(1);


                return landlist.First();

            }

        }
        // Call for antagonist and helper
        public static Cards RandomCreature()
        {
            using (var ctx = new CardContext())
            {
                var creatureList = ctx.Cards.Where(l => l.Type.Contains("Creature") || l.Type.Contains("PlanesWalker")).OrderBy(r => Guid.NewGuid()).Take(1);


                return creatureList.First();

            }
        }

    }
}