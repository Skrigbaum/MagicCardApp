using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MagicApp.Domain
{
    public class Cards
    {

        public Cards()
        {
           
        }



        public string Id { get; set; }
        public string Artist { get; set; }
        public string ImageName { get; set; }
        public string MultiverseId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        

    }
}