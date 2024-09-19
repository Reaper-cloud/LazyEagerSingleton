class Program
{
    static void Main(string[] args)
    {
        var lazyServers = Servers.Instance;
        Console.WriteLine(lazyServers.AddServer("http://lazysite.com")); 
        Console.WriteLine(lazyServers.AddServer("https://lazysite.com"));
        Console.WriteLine(lazyServers.AddServer("http://lazysite.com")); 
        Console.WriteLine(string.Join(", ", lazyServers.GetHttpServers()));
        Console.WriteLine(string.Join(", ", lazyServers.GetHttpsServers()));

        var eagerServers = EagerServers.Instance;
        Console.WriteLine(eagerServers.AddServer("https://eagersite.com"));
        Console.WriteLine(string.Join(", ", eagerServers.GetHttpsServers()));
    }
}