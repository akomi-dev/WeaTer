namespace WeatherTerminal;

public static class lib
{
    static HttpClient client = new HttpClient();

    static readonly string key = "f9d7dece96d2f9b77cc742253c2ae6d6";

    /// <summary>
    /// Call OpenWeather Geocoding API to get lon & lat. Must use ISO 3166 country codes.
    /// </summary>
    /// <param name="location">e.g. London,GB</param>
    public static async Task GeoLoc(string location)
    {
        string url = $"http://api.openweathermap.org/geo/1.0/direct?q={location}&appid={key}";

        string? responseBody = await client.GetStringAsync(url);

        dynamic? json = JsonConvert.DeserializeObject(responseBody);

        Data.lat = json?[0]["lat"];
        Data.lon = json?[0]["lon"];
    }
}