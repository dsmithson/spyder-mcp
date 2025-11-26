using Spyder.Client;
using Spyder.Client.Net;
using System.Reflection;

namespace SpyderMcp.Server;

public class PropertyInspector
{
    public static void InspectSpyderTypes()
    {
        Console.WriteLine("=== ISpyderClientExtended Properties ===");
        var clientType = typeof(ISpyderClientExtended);
        foreach (var prop in clientType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            Console.WriteLine($"{prop.Name}: {prop.PropertyType.Name}");
        }

        Console.WriteLine("\n=== BindableSpyderClient Properties ===");
        var bindableType = typeof(BindableSpyderClient);
        foreach (var prop in bindableType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            Console.WriteLine($"{prop.Name}: {prop.PropertyType.Name}");
        }
    }
}
