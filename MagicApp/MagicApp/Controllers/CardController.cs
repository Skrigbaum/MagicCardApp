﻿using System;
using System.Collections.Generic;
using System.Linq;
using MagicApp.Domain;

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
        public static Cards RandomCreatureorEnchantment()
        {
            using (var ctx = new CardContext())
            {
                var sorcery = ctx.Cards.Where(s => s.Type.Contains("Creature")).OrderBy(r => Guid.NewGuid()).Take(1);


                return sorcery.First();

            }

        }


        //Call to retrieve the Setting
        public static Cards RandomLand()
        {
            using (var ctx = new CardContext())
            {
                var landlist = ctx.Cards.Where(l => l.Type.Contains("land")).OrderBy(r => Guid.NewGuid()).Take(1);


                return landlist.First();

            }

        }
        // Call for antagonist and helper
        public static Cards RandomCreature()
        {
            using (var ctx = new CardContext())
            {
                var creatureList = ctx.Cards.Where(l => l.Type.Contains("Creature")).OrderBy(r => Guid.NewGuid()).Take(1);


                return creatureList.First();

            }
        }

    }
}