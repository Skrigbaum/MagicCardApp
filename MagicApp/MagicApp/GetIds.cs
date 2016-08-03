using MagicApp.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;

namespace MagicApp
{
    class GetIds
    {
        //connection string for api
        private const string url = "https://api.deckbrew.com/mtg/cards?name=";
        private static string id;


        public static string ParseResponse(string input)
        {

           var reponse = GetMultiverseId(input);

            dynamic array = JsonConvert.DeserializeObject(reponse);

            foreach (var item in array)
            {
               foreach (var x in item["editions"])
                {
                    try
                    {
                        if (x.multiverse_id != 0 || !string.IsNullOrWhiteSpace(x.multiverse_id))
                        {

                            id = x.multiverse_id.ToString();
                            break;
                        }
                        else
                        {
                            id = "0";
                            return id;
                        }
                    }
                    catch (RuntimeBinderException)
                    {
                        id = "0";
                        return id;
                    }
                    

                }


                return id;

            }

            


           /* using (var ctx = new CardContext())
            {
                ctx.Cards;
                ctx.Cards.Add();
                ctx.SaveChanges();
            }
            */
            return id;
        }

        public static string  GetMultiverseId(string input)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url + input);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }

            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
            
        }
        
    }
}
