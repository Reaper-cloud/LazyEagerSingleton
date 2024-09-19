using System;
using System.Collections.Generic;
using System.Linq;

public class EagerServers
{
    private static readonly EagerServers _instance = new EagerServers();
    private static readonly object _lock = new object();
    private readonly HashSet<string> _servers;

    private EagerServers()
    {
        _servers = new HashSet<string>();
    }

    public static EagerServers Instance
    {
        get
        {
            return _instance;
        }
    }

    public bool AddServer(string address)
    {
        if (!address.StartsWith("http://") && !address.StartsWith("https://"))
        {
            return false;
        }

        lock (_lock)
        {
            return _servers.Add(address);
        }
    }

    public List<string> GetHttpServers()
    {
        lock (_lock)
        {
            return new List<string>(_servers.Where(s => s.StartsWith("http://")));
        }
    }

    public List<string> GetHttpsServers()
    {
        lock (_lock)
        {
            return new List<string>(_servers.Where(s => s.StartsWith("https://")));
        }
    }
}
