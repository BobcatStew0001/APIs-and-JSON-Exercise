using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;
namespace APIsAndJSON
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("------Exercise 1-----");
            Console.WriteLine($"Hey Kayne {RonVSKanyeAPI.GetRonQuote()}");
            Console.WriteLine($"That's cool Ron, but {RonVSKanyeAPI.GetKanyeQuote()}");
            Console.WriteLine($"That is fascinating Kayne, but I think {RonVSKanyeAPI.GetRonQuote()}");
            Console.WriteLine($"Cool Ron, but I thought {RonVSKanyeAPI.GetKanyeQuote()}");
            Console.WriteLine($"Well Ron I also wanted to share this piece of wisdom {RonVSKanyeAPI.GetKanyeQuote()}");
            Console.WriteLine($"You are wise Kayne and I always said {RonVSKanyeAPI.GetRonQuote()}");
            Console.WriteLine($"Well Kayne I need to go but let me leave you with this {RonVSKanyeAPI.GetRonQuote()}");
            Console.WriteLine("------End of Exercise 1-----");
            Console.WriteLine("------Exercise 2-----");
            Console.WriteLine(APIsAndJSON.Weather.GetFormattedWeather());
            Console.WriteLine("------End of Exercise 2-----");

        }
        
    }
}