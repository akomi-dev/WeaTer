namespace WeatherTerminal;

class Program
{
    static async Task Main(string[] args)
    {
        await init();


        Console.WriteLine(Data.lon);
        Console.WriteLine(Data.lat);
     }

    /// <summary>
    /// Initial function that is always called on program start.
    /// Data Class:
    /// Set username and location with init;
    /// Set lon and lat with GeoLoc.
    /// </summary>
    static async Task init()
    {
        string fullpath = "data.json";
        Data? data = JsonConvert.DeserializeObject<Data>(fullpath);

        Console.WriteLine(data);

        await lib.GeoLoc("london,gb");
    }
}
