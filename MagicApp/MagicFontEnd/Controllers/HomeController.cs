using System.Drawing;
using System.Web.Mvc;
using WebGrease.Css.ImageAssemblyAnalysis;

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
            //var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + Land.MultiverseId + "&type=card";

            var ImgUrl = "/Images/Modern Masters/Absorb Vis.full.jpg";
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