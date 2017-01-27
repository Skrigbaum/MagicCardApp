using MagicApp.Domain;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

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
                                    if (cards.flavor != null && !string.IsNullOrWhiteSpace(cards.flavor.ToString()))
                                    {
                                        if (cards.mciNumber == null || string.IsNullOrWhiteSpace(cards.mciNumber.ToString()))
                                        {
                                            try
                                            {
                                                cards.mciNumber = cards.number;
                                            }
                                            catch
                                            {
                                                cards.mciNumber = 0;
                                            }
                                        }
                                        carding = new Cards()
                                        {
                                            Artist = cards.artist.ToString(),
                                            Id = cards.id.ToString(),
                                            Name = cards.name,
                                            ImageName = cards.imageName.ToString(),
                                            Type = cards.type.ToString(),
                                            MultiverseId = cards.multiverseid.ToString(),
                                            Rarity = cards.rarity.ToString(),
                                            Flavor = cards.flavor.ToString(),
                                            Set = sets.code.ToString(),
                                            mciNumber = cards.mciNumber.ToString()
                                        };
                                    }
                                    else
                                    {
                                        if (cards.mciNumber == null || string.IsNullOrWhiteSpace(cards.mciNumber.ToString()))
                                        {
                                            try
                                            {
                                                cards.mciNumber = cards.number;
                                            }
                                            catch
                                            {
                                                cards.mciNumber = 0;
                                            }
                                        }
                                        carding = new Cards()
                                        {
                                            Artist = cards.artist.ToString(),
                                            Id = cards.id.ToString(),
                                            Name = cards.name,
                                            ImageName = cards.imageName.ToString(),
                                            Type = cards.type.ToString(),
                                            MultiverseId = cards.multiverseid.ToString(),
                                            Rarity = cards.rarity.ToString(),
                                            Set = sets.code.ToString(),
                                            mciNumber = cards.mciNumber.ToString()

                                        };
                                    }
                                }
                                //Assign to card object if multiverse Id is not valid
                                catch (RuntimeBinderException)
                                {
                                    if (cards.flavor != null && !string.IsNullOrWhiteSpace(cards.flavor.ToString()))
                                    {
                                        if (cards.mciNumber == null || string.IsNullOrWhiteSpace(cards.mciNumber.ToString()))
                                        {
                                            try
                                            {
                                                cards.mciNumber = cards.number;
                                            }
                                            catch
                                            {
                                                cards.mciNumber = 0;
                                            }
                                        }
                                        carding = new Cards()

                                        {
                                            Artist = cards.artist.ToString(),
                                            Id = cards.id.ToString(),
                                            Name = cards.name,
                                            ImageName = cards.imageName.ToString(),
                                            Type = cards.type.ToString(),
                                            Rarity = cards.rarity.ToString(),
                                            Flavor = cards.flavor.ToString(),
                                            Set = sets.code.ToString(),
                                            mciNumber = cards.mciNumber.ToString()
                                        };
                                    }
                                     else
                                    {
                                        if (cards.mciNumber == null || string.IsNullOrWhiteSpace(cards.mciNumber.ToString()))
                                        {
                                            try
                                            {
                                                cards.mciNumber = cards.number;
                                            }
                                            catch
                                            {
                                                cards.mciNumber = 0;
                                            }
                                        }
                                        carding = new Cards()
                                        {
                                            Artist = cards.artist.ToString(),
                                            Id = cards.id.ToString(),
                                            Name = cards.name,
                                            ImageName = cards.imageName.ToString(),
                                            Type = cards.type.ToString(),
                                            Rarity = cards.rarity.ToString(),
                                            Set = sets.code.ToString(),
                                            mciNumber = cards.mciNumber.ToString()

                                        };
                                    }


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
