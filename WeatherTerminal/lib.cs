global using System;
global using System.Threading.Tasks;
global using System.Collections;
global using System.Net.Http;
global using Newtonsoft.Json;


namespace WeatherTerminal;

partial class Program
{
    static readonly HttpClient client = new();

    static readonly string key = "f9d7dece96d2f9b77cc742253c2ae6d6";

    public static async Task GeoLoc(string? location)
    {
        string url = $"http://api.openweathermap.org/geo/1.0/direct?q={location}&appid={key}";

        string? responseBody = await client.GetStringAsync(url);

        dynamic? json = JsonConvert.DeserializeObject(responseBody);

        lat = json?[0]["lat"];
        lon = json?[0]["lon"];
    }

    public static async Task<ArrayList> Weather()
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}";

        string? responseBody = await client.GetStringAsync(url);

        dynamic? json = JsonConvert.DeserializeObject(responseBody);

        ArrayList weather = new()
        {
            $"Main: {json?["weather"][0]["main"]}\n",
            $"Temperature:",
            $"\tTemp: {(json?["main"]["temp"] - 273.15).ToString("#.##")} °C",
            $"\tTemp High: {(json?["main"]["temp_min"] - 273.15).ToString("#.##")} °C",
            $"\tTemp Low: {(json?["main"]["temp_max"] - 273.15).ToString("#.##")} °C",
            $"Wind:",
            $"\tWind Speed: {json?["wind"]["speed"]} km/h",
            $"\tWind Direction: {json?["wind"]["deg"]} °",
        };

        return weather;
    }
}