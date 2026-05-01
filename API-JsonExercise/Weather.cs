using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; 
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
namespace APIsAndJSON;

public class Weather
{
    //Get the city Information
    public static string GetCity()
    {
        Console.WriteLine("Enter your zip code:");
        return Console.ReadLine();
    }
    static string myCity = GetCity();//Make the city info useable in the API call 

    static IConfigurationRoot config = new ConfigurationBuilder()//Make the API key useable in the API call
        .AddJsonFile("appsettings.json")
        .Build();

    private static string? apiKey = config["key"]; 

    public static string GetWeather()//Make the API call
    {
        var clientHttp = new HttpClient(); 
        var clientResponse = clientHttp.GetAsync($"https://api.openweathermap.org/geo/1.0/zip?zip={myCity},US&appid={apiKey}&units=imperial").Result;
        return clientResponse.Content.ReadAsStringAsync().Result;
    }

    private static string geoResponse = GetWeather();//Per OpenWeather make the GetCity use US Zip Code
    static string? cityLat = JObject.Parse(geoResponse).GetValue("lat").ToString();
    static string? cityLon = JObject.Parse(geoResponse).GetValue("lon").ToString();
    
    public static string GetWeatherData()//Second API call to get the weather data
    {
        var clientHttp = new HttpClient(); 
        var clientResponse = clientHttp.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={cityLat}&lon={cityLon}&appid={apiKey}&units=imperial").Result;
        return clientResponse.Content.ReadAsStringAsync().Result;
    }

    public static string GetFormattedWeather()
    {
        Console.WriteLine("Welcome to Zach's Weather App");
        string? cityName = JObject.Parse(geoResponse).GetValue("name").ToString();
        string weatherDataResponse =
        GetWeatherData();
        JObject mainObject =
        (JObject)JObject.Parse(weatherDataResponse).GetValue("main");
        string? tempObject =
        mainObject.GetValue("temp").ToString();
        
        string? humidityObject =
        mainObject.GetValue("humidity").ToString();
        
        string? feelsLikeObject =
        mainObject.GetValue("feels_like").ToString();
        
        var client = new HttpClient();
        var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        var ronResponse = client.GetStringAsync(ronUrl).Result;
        var ron = JArray.Parse(ronResponse)[0];
        
        return $"The weather in {cityName} is {tempObject} degrees Fahrenheit with a feel like of {feelsLikeObject} degrees Fahrenheit, and humidity of {humidityObject}%. \n Words of Wisdon from Ron: {ron}";
    }
}