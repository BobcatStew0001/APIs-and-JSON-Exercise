using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    {
        public static string GetRonQuote()
        {
            var client = new HttpClient();
            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronUrl).Result;
            var ron = JArray.Parse(ronResponse)[0];
            return ron.ToString();
        }

        public static string GetKanyeQuote()
        {
            var client = new HttpClient();
            var kayneUrl = "https://api.kanye.rest/";
            var kayneResponse = client.GetStringAsync(kayneUrl).Result;
            var kayne = JObject.Parse(kayneResponse).GetValue("quote").ToString();
            return kayne;
        }
    }
    
}   

