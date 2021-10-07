using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Enter your API key:");
            var apiKey = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter your CITY name:");
                var city = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={apiKey}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.WriteLine("");

                Console.WriteLine("Would you like to choose a different city?");
                var choice = Console.ReadLine();
                Console.WriteLine("");
                if (choice.ToLower() == "no")
                {
                    break;
                }

            }
        }
    }
}
