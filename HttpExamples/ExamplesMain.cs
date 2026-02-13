using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace C_Sharp.HttpExamples;

public static class HttpMainExamples
{
	public static async Task HttpExamples()
	{
		// await GetAllTodos();
		// await GetAllTodosByJson();
		await GetAllTodoById();
		// await GetHttp();
		// await GetHttpWhenAll();

	}

	public static async Task GetAllTodos()
	{
		using var client =  new HttpClient();
		var response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos");
		if (response.IsSuccessStatusCode)
		{
			var content = await response.Content.ReadAsStringAsync();
			Console.WriteLine(content);
		}
	}

	public record Todo(int UserId, int Id, string Title, bool Completed);

	public static async Task GetAllTodosByJson()
	{
		using var client = new HttpClient();
		var response = await client.GetFromJsonAsync<List<Todo>>("https://jsonplaceholder.typicode.com/todos");
		response.ForEach(Console.WriteLine);
	}

	public static async Task GetAllTodoById()
	{
		using var client =  new HttpClient();
		var response = await client.GetFromJsonAsync<Todo>("https://jsonplaceholder.typicode.com/todos/99");
		Console.WriteLine(response);
	}

	public static async Task GetAllTodoByIdBearerToken()
	{
		using var client =  new HttpClient();
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Beare", "<my-token>");
		var response = await client.GetFromJsonAsync<Todo>("https://jsonplaceholder.typicode.com/todos/99");
		Console.WriteLine(response);
	}


	public static async Task GetHttp()
	{
		using var client = new HttpClient();
		// Getting 100 pokemones
		// Check PokeApi.json
		var pokeList = await client.GetFromJsonAsync<PokeListResponse>("https://pokeapi.co/api/v2/pokemon?limit=100");

		var typeCounts = new Dictionary<string, int>();

		Console.WriteLine("Fetching types for 100 pokemones ... please wait");
		foreach(var entry in pokeList!.Results)
		{
			// for every poken make a request in order to pick the types on the second request.
			// Check PokeTypes.json 
			var detail = await client.GetFromJsonAsync<PokeDetail>(entry.Url);

			foreach(var typeSlot in detail.Types)
			{
				string typeName = typeSlot.Type.Name!;
				if (typeName == "fire" || typeName == "water" )
				{
					if (typeCounts.ContainsKey(typeName))
							typeCounts[typeName]++;
					else
							typeCounts[typeName] = 1;
				}
			}
		}

		// 3. Print the summary
		Console.WriteLine("\n--- Type Summary (First 100) ---");
		foreach (var kvp in typeCounts.OrderByDescending(x => x.Value))
		{
			Console.WriteLine($"{char.ToUpper(kvp.Key[0]) + kvp.Key.Substring(1)}: {kvp.Value}");
		}		
	}
	

	public static async Task GetHttpWhenAll()
	{
		using var client = new HttpClient();
		var pokeList = await client.GetFromJsonAsync<PokeListResponse>("https://pokeapi.co/api/v2/pokemon?limit=100");

		// 1. Create a list of Tasks (each task represents an HTTP request)
    var tasks = pokeList.Results.Select(p => client.GetFromJsonAsync<PokeDetail>(p.Url));

		PokeDetail[] results = await Task.WhenAll(tasks);

		var typeCounts = results
					.SelectMany(d => d.Types)
          .Where(d => d.Type.Name == "fire" || d.Type.Name == "water") // Filter logic
					.GroupBy(t => t.Type.Name)
					.Select(g => new {Type = g.Key, Count = g.Count() })
					.OrderByDescending(x => x.Count);


		// 4. Print the summary
		Console.WriteLine("\n--- Type Summary (Parallel Fetch) ---");
		foreach (var item in typeCounts)
		{
			Console.WriteLine($"{char.ToUpper(item.Type[0]) + item.Type.Substring(1)}: {item.Count}");
		}	
	}
// Data Transfer Objects (DTOs) for JSON Deserialization
	public record PokeListResponse(List<PokeEntry> Results);
	public record PokeEntry(string Url);


  public record PokeDetail(List<SlotType> Types);
	public record SlotType (TypeName Type);
	public record TypeName (string Name );
}
