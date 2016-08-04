using System;
using System.Collections.Generic;
using MagicApp.Domain;

namespace MagicApp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Load Json into Database
            // int counter = 0;

            //Assigns results of Json Parsing to list of values
            // IList<Cards> values = LoadJson.Load();

            // Populate database with List Values
            /* foreach (var v in values)
               {


                   using ( var ctx = new CardContext())
                   {
                       ctx.Cards.Add(v);
                       ctx.SaveChanges();
                   }
                   //counts the total cards added
                   counter++;
               }
               */
            #endregion


            #region  Test print to check for proper generation
            /*
            var problem = CardController.RandomCreatureorEnchantment();
            var sorc =  CardController.RandomSorceryorArtifact();
            var land = CardController.RandomLand();
            var helper = CardController.RandomCreature();
            var antag = CardController.RandomCreature();
                
                //problem print
                Console.WriteLine("You have Drawn the: " + problem.Name);
                Console.WriteLine("This is the Problem");



                //solution print
                Console.WriteLine("\n");
                Console.WriteLine("You have Drawn the: " + sorc.Name);
                Console.WriteLine("This is the Solution");

                //setting print
                Console.WriteLine("\n");
                Console.WriteLine("You have drawn a: " + land.Name);
                Console.WriteLine("This is the Setting");

                //helper print
                Console.WriteLine("\n");
                Console.WriteLine("You have drawn a: " + helper.Name);
                Console.WriteLine("This is the Helper");

                //antagonist print
                Console.WriteLine("\n");
                Console.WriteLine("You have drawn a: " + antag.Name);
                Console.WriteLine("This is the Antagonist");



            Console.ReadKey();
            */
            #endregion

            #region import Multiverse id's
            //Creates list of all cards with Mutliverse id's of null
            //var list = CardListOfNull.LoadList();

            //Creates list of all Cards with Multiverse Id's of 0
            var list = CardListOfNull.LoadZeroList();


            //loops through all cards in list and fetches Id
            foreach (var x in list)
            {
                string response = GetIds.ParseResponse(x.Name);
                //  Console.WriteLine(x.Name);
                // Console.WriteLine(response);


                //replaces null or 0 with fetched ID
                using (var ctx = new CardContext())
                {


                    ctx.Database.ExecuteSqlCommand(
                        $"update [MagicApp.Domain.CardContext].dbo.Cards set MultiverseId = '" + response +
                        "' where name like {0} ;", x.Name);



                    Console.WriteLine("update [MagicApp.Domain.CardContext].dbo.Cards set MultiverseId = '" +
                                      response + "' where name = '" + x.Name + "'");
                    ctx.SaveChanges();



                }


            }
            #endregion

            Console.WriteLine("All Done");
            Console.ReadKey();

        }
    }
}
