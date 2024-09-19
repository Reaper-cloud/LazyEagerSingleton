using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Servers
{
    private static Servers _instance;
    private static readonly object _lock = new object();
    private readonly HashSet<string> _servers;

    private Servers()
    {
        _servers = new HashSet<string>();
    }

    public static Servers Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Servers();
                }
                return _instance;
            }
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
