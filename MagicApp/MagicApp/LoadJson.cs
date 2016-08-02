using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicApp.Domain;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MagicApp
{
    class LoadJson
    {

        public static List<Cards> Load()
        {
            using (
                StreamReader r = new StreamReader("..\\..\\AllSets.json"))
            {
                string json = r.ReadToEnd();

                dynamic array = JsonConvert.DeserializeObject(json);

                List<Cards> allnames = new List<Cards>();

                foreach (var item in array)
                {
                    foreach (var sets in item)
                    {

                        foreach (var cards in sets.cards)
                        {
                            if (cards.name != null && !string.IsNullOrWhiteSpace(cards.id.ToString()))
                            {

                                Cards carding = null;
                                try
                                {
                                    carding = new Cards()
                                    {
                                        Artist = cards.artist.ToString(),
                                        Id = cards.id.ToString(),
                                        Name = cards.name,
                                        ImageName = cards.imageName.ToString(),
                                        Type = cards.type.ToString(),
                                        MultiverseId = cards.multiverseid.ToString()
                                    };
                                }
                               catch(RuntimeBinderException)
                                {
                                    
                                    carding = new Cards()
                                    {
                                        Artist = cards.artist.ToString(),
                                        Id = cards.id.ToString(),
                                        Name = cards.name,
                                        ImageName = cards.imageName.ToString(),
                                        Type = cards.type.ToString(),
                                        
                                    };
                                }

                                allnames.Add(carding);

                            }

                        }
                    }
                }


                return allnames;





            }




        }
    }
}
