using System.Drawing;
using System.Web.Mvc;
using WebGrease.Css.ImageAssemblyAnalysis;
using System.IO;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace MagicFontEnd.Controllers
{
    public class HomeController : Controller
    {
        private static string theProblem = "";
        private static string theSetting = "";
        private static string theSolution = "";
        private static string theHelper = "";
        private static string theAntagonist = "";

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
            
           
                var creature = MagicApp.Controllers.CardController.Problem();
                theProblem = creature.MultiverseId;
                var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + creature.MultiverseId + "&type=card";
                var magicurl = "http://magiccards.info/scans/en/" + creature.Set + "/" + creature.mciNumber + ".jpg";
                return ImgUrl;
            
      
        }

           

        public string Land()
        {
            var Land = MagicApp.Controllers.CardController.RandomLand();
            var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + Land.MultiverseId + "&type=card";

            if (System.IO.File.Exists(@"C:\Users\skrigbaum\MagicCardApp\MagicApp\MagicFontEnd\Images\" + Land.Name + ".full.jpg"))
            {
                ImgUrl =  @"\Images\" + Land.Name +".full.jpg";
                theSetting = Land.MultiverseId;
                return ImgUrl;
            }
            else
            {
                theSetting = Land.MultiverseId;
                return ImgUrl;
            }
            


        }

        public string Helper()
        {
            var helper = MagicApp.Controllers.CardController.RandomCreature();
            var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + helper.MultiverseId + "&type=card";
            if (System.IO.File.Exists(@"C:\Users\skrigbaum\MagicCardApp\MagicApp\MagicFontEnd\Images\" + helper.Name + ".full.jpg"))
            {
                ImgUrl = @"\Images\" + helper.Name + ".full.jpg";
                theHelper = helper.MultiverseId;
                return ImgUrl;
            }
            else
            {
                theHelper = helper.MultiverseId;
                return ImgUrl;
            }
        }
        
        public string Antagonist()
        {
            var antagonist = MagicApp.Controllers.CardController.Problem();
            var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + antagonist.MultiverseId + "&type=card";
            if (System.IO.File.Exists(@"C:\Users\skrigbaum\MagicCardApp\MagicApp\MagicFontEnd\Images\" + antagonist.Name + ".full.jpg"))
            {
                ImgUrl = @"\Images\" + antagonist.Name + ".full.jpg";
                theAntagonist = antagonist.MultiverseId;
                return ImgUrl;
            }
            else
            {
                theAntagonist = antagonist.MultiverseId;
                return ImgUrl;
            }




        }


        public string Solution()
        {
            var solution = MagicApp.Controllers.CardController.RandomSorceryorArtifact();
            var ImgUrl = "http://gatherer.wizards.com/Handlers/Image.ashx?multiverseid=" + solution.MultiverseId + "&type=card";
            if (System.IO.File.Exists(@"C:\Users\skrigbaum\MagicCardApp\MagicApp\MagicFontEnd\Images\" + solution.Name + ".full.jpg"))
            {
                ImgUrl = @"\Images\" + solution.Name + ".full.jpg";
                theSolution = solution.MultiverseId;
                return ImgUrl;
            }
            else
            {
                theSolution = solution.MultiverseId;
                return ImgUrl;
            }
        }

        public string Save()
        {
            string idConcat = string.Format("{0}|{1}|{2}|{3}|{4}", theProblem, theSetting, theSolution, theHelper, theAntagonist);
            return idConcat;
        }

        public string Load(string codes)
        {
            string[] CodeArray = new string[5];
           CodeArray = codes.Split('|');
            var jsonArray = JsonConvert.SerializeObject(CodeArray);
            return jsonArray;
            
        }
    }
}