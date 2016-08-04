﻿using System;
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
            //read Json file
            using (
                StreamReader r = new StreamReader("..\\..\\AllSets.json"))
            {
                string json = r.ReadToEnd();

                //Stuff Converted Json into variable
                dynamic array = JsonConvert.DeserializeObject(json);

                List<Cards> allnames = new List<Cards>();

                //Access top level
                foreach (var item in array)
                {
                    //Access Set level
                    foreach (var sets in item)
                    {
                        //Access Card level...Finally
                        foreach (var cards in sets.cards)
                        {
                            //Check for blank or empty cards
                            if (cards.name != null && !string.IsNullOrWhiteSpace(cards.id.ToString()))
                            {

                                Cards carding = null;
                                //Assign card to card object of Multiverse Id is valid
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
                                //Assign to card object if multiverse Id is not valid
                                catch (RuntimeBinderException)
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

                //Return List
                return allnames;





            }




        }
    }
}
