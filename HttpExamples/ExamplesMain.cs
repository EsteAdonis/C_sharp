using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;


// learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient
// Next topic:
//		Explore the HTTP HEAD request
//		Explore the HTTP OPTIONS request
//    and so on...


namespace C_Sharp.HttpExamples;

public static class HttpMainExamples
{
	public static async Task HttpExamples()
	{
  	string Uri = "https://jsonplaceholder.typicode.com/";
		using var client = new HttpClient(){ BaseAddress = new Uri(Uri) } ; 
		// await GetAllTodos(client);
		// await GetAllTodosByJson(client);
		// await GetAllTodoById(client);
		// await PostTodo(client);
		// await PostTodoJson(client);
		// await HttpDelete(client, "1");
		// await HttpPut(client, 1);
		// await HttpPutJsonAsync(client, 5);
		// await HttpPatch(client, 5);
		// await HttpHeader(client);
		// await HttpOptions(client);
		// await GetHttp(client);
		// await GetHttpWhenAll(client);
	}

	public static async Task HttpOptions(HttpClient client)
	{
		// The OPTIONS request method describes the communication options for the target resource. 
		// This request method allows a client to determine the options and/or requirements associated with a resource, 
		// or the capabilities of a server, without implying a resource action or initiating a resource retrieval.
		using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

		using HttpRequestMessage request = new (HttpMethod.Options, "todos/1");
		try {
			using var response = await client.SendAsync(request, cts.Token);
			
			response.EnsureSuccessStatusCode();

			foreach(var header in response.Headers)
			{
				Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
			}
		}
		catch (OperationCanceledException ex) when (ex.InnerException is TimeoutException tex)
		{
    // when the time-out occurred. Here the cancellation token has not been canceled.
    Console.WriteLine($"Timed out: {ex.Message}, {tex.Message}");
		}
	}



	public static async Task HttpHeader(HttpClient client)
	{
		// this request returns only the headers associated with the resource. 
		// A response to the HEAD request doesn't return a body. 

		using HttpRequestMessage request = new (HttpMethod.Get, "todos/1");
		using var response = await client.SendAsync(request);
		
		response.EnsureSuccessStatusCode();

		foreach(var header in response.Headers)
		{
			Console.WriteLine($"{header.Key}: {string.Join(", ", header.Value)}");
		}
	}

	public static async Task HttpPatch(HttpClient client, int id)
	{
		// The PATCH request is a partial update to an existing resource. 
		// This request doesn't create a new resource and ...
		// it isn't intended to replace an existing resource. 

		using StringContent jsonContent = new (
				JsonSerializer
						.Serialize(new { completed = true }), 
					 	 Encoding.UTF8,
					 	 "application/json"
				);

		using var response = await client.PatchAsync($"todos/{id}", jsonContent);
		response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();
		Console.WriteLine($"{jsonResponse}\n");
	}

	public static async Task HttpPut(HttpClient client, int id)
	{
		// The PUT request method either replaces an existing resource or ...
		// creates a new one by using the request body payload. 

		using StringContent jsonContent = new (
				JsonSerializer.Serialize(new
				{
					userId = 1,
					id = 1,
					title = "foo bar",
					completed = false				
				}),
				Encoding.UTF8,
				"application/json"
		);

		using var response = await client.PutAsync($"todos/{id}", jsonContent);
		response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();
		Console.WriteLine($"{jsonResponse}\n");
	}

	static async Task HttpPutJsonAsync(HttpClient client, int id)
	{
		// To automatically serialize PUT request arguments and .... 
		// deserialize responses into strongly typed C# objects, 
		// use the PutAsJsonAsync and the ReadFromJsonAsync extension methods, 
		// respectively, that are part of the System.Net.Http.Json NuGet package.
		
		using var response = await client.PutAsJsonAsync(
					$"todos/{id}",
					new Todo(Title: "partially update todo", Completed: true));

		response.EnsureSuccessStatusCode();

		var todo = await response.Content.ReadFromJsonAsync<Todo>();
		Console.WriteLine($"{todo}\n");

			// Expected output:
			//   PUT https://jsonplaceholder.typicode.com/todos/5 HTTP/1.1
			//   Todo { UserId = , Id = 5, Title = partially update todo, Completed = True }
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

	public record Todo(int? UserId=null, int? Id=null, string Title=null, bool? Completed=null);

	public static async Task GetAllTodosByJson(HttpClient client)
	{
		var response = await client.GetFromJsonAsync<List<Todo>>("todos");
		response.ForEach(Console.WriteLine);
	}

	public static async Task GetAllTodoById(HttpClient client)
	{
		var response = await client.GetFromJsonAsync<Todo>("todos/99");
		Console.WriteLine(response);
	}

	public static async Task GetAllTodoByIdBearerToken(HttpClient client)
	{
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Beare", "<my-token>");
		var response = await client.GetFromJsonAsync<Todo>("todos/99");
		Console.WriteLine(response);
	}

	public static async Task PostTodo(HttpClient client)
	{
		using StringContent jsonContent = new (JsonSerializer.Serialize(new {userId=301, id=1, title="Adonis Sample", Complete=false}), Encoding.UTF8, "application/json");
    using var response = await client.PostAsync("todos", jsonContent);
		var result = response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();
		Console.WriteLine($"{jsonResponse}\n");
	}

	public static async Task PostTodoJson(HttpClient client)
	{
		var todoData = new Todo(UserId: 9, Id: 99, Title: "Show extensions", Completed: false);

		using var response = await client.PostAsJsonAsync("todos", todoData);

		response.EnsureSuccessStatusCode();
		var todo = await response.Content.ReadFromJsonAsync<Todo>();
		Console.WriteLine($"{todo}\n");
	}


	public static async Task HttpDelete(HttpClient client, string id)
	{
		using var response = await client.DeleteAsync($"todos/{id}");
		response.EnsureSuccessStatusCode();

		var jsonResponse = await response.Content.ReadAsStringAsync();
		Console.WriteLine($"{jsonResponse}\n");
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
