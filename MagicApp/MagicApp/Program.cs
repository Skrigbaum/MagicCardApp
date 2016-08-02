using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MagicApp.Controllers;
using MagicApp.Domain;

namespace MagicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //int counter = 0;

           // IList<Cards> values = LoadJson.Load();

            // used to populate database
            
                             
           /* foreach (var v in values)
            {

              
                using ( var ctx = new CardContext())
                {
                    ctx.Cards.Add(v);
                    ctx.SaveChanges();
                }
                
                counter++;
            }
            */

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
        }
    }
}
