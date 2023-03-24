namespace WeatherTerminal;

partial class Program
{
    public static readonly string ConfigFilePath = @"config.txt";
    public static double lat, lon;

    static async Task Main(string[] args)
    {
        await init();
        dynamic output = await Weather();
        Console.WriteLine();
        foreach (var item in output)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("\nPress enter to exit.");
     }

    /// <summary>
    /// Initial function that is always called on program start.
    /// Data Class:
    /// Set username and location with init;
    /// Set lon and lat with GeoLoc.
    /// </summary>
    static async Task init()
    {
        Console.Write("Please enter your location (ex: London, GB): ");
        string? location = Console.ReadLine()?.Replace(" ", "");

        await GeoLoc(location);
    }
}
