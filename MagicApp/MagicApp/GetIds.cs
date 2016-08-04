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
        //connection string for api call for Multiverse Id's
        private const string url = "https://api.deckbrew.com/mtg/cards?name=";
        private static string id;

        //Return valid Multiverse Id
        public static string ParseResponse(string input)
        {
            //Call APi
            var reponse = GetMultiverseId(input);
            //parse response
            dynamic array = JsonConvert.DeserializeObject(reponse);

            //Access Toplevel of response
            foreach (var item in array)
            {
                //Access Edition level that stores Id's
                foreach (var x in item["editions"])
                {
                    //If Found valid id assign and move on
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

                        }
                    }
                    catch (RuntimeBinderException)
                    {
                        id = "0";

                    }


                }


                return id;

            }
            return id;
        }

        //Contact Web Api to get JSON response
        public static string GetMultiverseId(string input)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + input);
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
