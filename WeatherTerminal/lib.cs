namespace WeatherTerminal;

partial class Program
{
    static readonly HttpClient client = new();

    static readonly string key = "f9d7dece96d2f9b77cc742253c2ae6d6";

    public static async Task GeoLoc(string? location)
    {
        string url = $"http://api.openweathermap.org/geo/1.0/direct?q={location}&appid={key}";

        dynamic? json = JsonConvert.DeserializeObject(await client.GetStringAsync(url));

        lat = json?[0]["lat"];
        lon = json?[0]["lon"];
    }

    public static async Task<ArrayList> Weather()
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}";

        dynamic? json = JsonConvert.DeserializeObject(await client.GetStringAsync(url));

        return new()
        {
            $"Main: {json?["weather"][0]["main"]}\n",
            $"Temperature:",
            $"\tTemp: {(((json?["main"]["temp"] - 273.15) * (9/5)) + 32).ToString("#.##")} °F",
            $"\tTemp High: {(((json?["main"]["temp_min"] - 273.15) * (9/5)) + 32).ToString("#.##")} °F",
            $"\tTemp Low: {(((json?["main"]["temp_max"] - 273.15) * (9/5)) + 32).ToString("#.##")} °F",
            $"Wind:",
            $"\tWind Speed: {(json?["wind"]["speed"] / 1.609).ToString("#.##")} m/h",
            $"\tWind Direction: {json?["wind"]["deg"]} °",
        };
    }
}