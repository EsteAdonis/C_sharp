namespace C_Sharp.Pattern.Design.Singleton;

public class Singleton()
{
	static Singleton? instance;

	public static Singleton Instance() => instance ??= new Singleton();
}


public sealed class LoadBalancer
{
	private static readonly LoadBalancer instance = new();

	private readonly List<Server> servers;
	private readonly Random random = new();

	private LoadBalancer()
	{
		servers = [
			new("ServerI", "120.14.220.18"),
			new("ServerII", "120.14.220.19"),
			new("ServerIII", "120.14.220.20"),
			new("ServerIV", "120.14.220.21"),
			new("ServerV", "120.14.220.22"),
		];
	}

	public static LoadBalancer GetLoadBalancer() => instance;

	public Server NextServer => servers[random.Next(servers.Count)];
}

static class EntrySingleton
{
	public static void ExecSingleton()
	{
		// Executing the basic model of Singleton
		Singleton s1 = Singleton.Instance();
		Singleton s2 = Singleton.Instance();

		// Exceuting the LoadBalancer

		var b1 = LoadBalancer.GetLoadBalancer();
		var b2 = LoadBalancer.GetLoadBalancer();
		var b3 = LoadBalancer.GetLoadBalancer();
		var b4 = LoadBalancer.GetLoadBalancer();
		var b5 = LoadBalancer.GetLoadBalancer();			

		if (b1 == b2 && b2 == b3 && b3 == b4 && b4 == b5)
		{
			Console.WriteLine("Same instance\n");
		}

		var balancer = LoadBalancer.GetLoadBalancer();;

		for (int i =0; i < 15; i++)
		{
			var server = balancer.NextServer.Name;
			Console.WriteLine("Dispatch request to: " + server);
		}
	}
}

/// <summary>
/// Represents a server maching
/// </summary>
/// <param name="Name">Server Name</param>
/// <param name="Ip">ip address</param>
public record Server(string Name, string Ip);