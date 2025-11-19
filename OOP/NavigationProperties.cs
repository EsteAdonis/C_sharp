using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Sharp.Data;
using C_Sharp.Models;
using Microsoft.EntityFrameworkCore;

namespace C_Sharp
{
	public static class NavigationProperties
	{
		public static void AddingAutorAndBooks()
		{
			// Creating Author(s) List
			List<Author> authors = [
				new() { FirstName = "Homer", LastName = "-Greek"},
				new() { FirstName = "Euripides", LastName = "-Greek"},
				new() { FirstName = "Plato", LastName = "-Greek"},
				new() { FirstName = "Aristotle", LastName = "-Greek"},
				new() { FirstName = "Sappho", LastName = "-Greek"},
				new() { FirstName = "Sophocles", LastName = "-Greek"},
				new() { FirstName = "Herodotus", LastName = "-Greek"},
				new() { FirstName = "Thucydides", LastName = "-Greek"},
				new() { FirstName = "Demosthenes", LastName = "-Greek"},
				new() { FirstName = "Hesiod", LastName = "-Greek"},
				new() { FirstName = "Aeschylus", LastName = "-Greek"},
				new() { FirstName = "Aristophanes", LastName = "-Greek"},
			];

			List<Book> books = [
				new() { Title="Timeless Greek poet known for his epic poems."},
				new() { Title="Medea, The Bacchae, Hippolytus, Alcestis."},
				new() { Title="Tragedian of classical Athens."},
				new() { Title="The Republic, Apology, Symposium, Phaedrus."},
				new() { Title="Nicomachean Ethics, Poetics, Politics, Metaphysics."},
				new() { Title="Known for his ideas recorded by Plato, such as in Apology."},
			  new() { Title="Oedipus Rex, Antigone, Electra."},
				new() { Title="Prometheus Bound, The Oresteia (Agamemnon, Libation Bearers, Eumenides"},
				new() { Title="Lysistrata, The Clouds, The Birds, The Frogs."}
			]; 

			var context = new DataContext();

  		context.Authors.AddRange(authors);
 			context.SaveChanges();
	

		 	var auth = context.Authors.FirstOrDefault(a => a.FirstName == "Plato");
			// At the last parameter assign the auth to Author as a reference to Author table
		  var boo = new Book() { Title="Tragedian of classical Athens.", AuthorId = 19};			
			auth!.Books.Add(boo); 
			context.SaveChanges();

			var authorsBooks = context
													.Authors
													.Include(b => b.Books)
													.ToList();

			var boos = authorsBooks[0].Books.ToList();			
			Console.WriteLine(boos);


		}
	}
}

