using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace MagicFontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
       public string Creature()
        {
           var creature = MagicApp.Controllers.CardController.RandomCreature();
           var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + creature.MultiverseId + "&type=card";

           return ImgUrl;


        }

        public string Land()
        {
            var Land = MagicApp.Controllers.CardController.RandomLand();
            var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + Land.MultiverseId + "&type=card";

            return ImgUrl;


        }

        public string Helper()
        {
            var helper = MagicApp.Controllers.CardController.RandomCreatureorEnchantment();
            var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + helper.MultiverseId + "&type=card";

            return ImgUrl;


        }

        public string Solution()
        {
            var solution = MagicApp.Controllers.CardController.RandomSorceryorArtifact();
            var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + solution.MultiverseId + "&type=card";

            return ImgUrl;


        }
    }
}