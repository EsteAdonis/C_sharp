using System.Net.NetworkInformation;
using Humanizer;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;

namespace C_Sharp.Strings;

public static class StringHandling
{
	public static void MainExcuting()
	{
		ImmutableString();
		StringBuilderAndString();
		ComparingString();
		NullOrWiteSpace();
		StringComparision();
		StringReplace();
		StringOperationsThrow();
		Palindrome("amor a roma");
		DetectDuplicates("amor a roma");
		ReverseString("Adonis Siempre Avante");
		CountConcurrences("Adonis Siempre Avante");
		NonRepeatingChar("Adonis Siempre Avante");
		RemoveDuplicated("Adonis Siempre Avante");
		AreAnagrams("Adonis Siempre Avante", "Adonis Siempre Avante");
		FindCommonElement(["Adonis", "Eris", "Atenea"], ["Atenea", "Amy", "Vanessa", "Odiseo", "Adonis"]);
		CountVowelsAndConsonants("Adonis Siempre Avante");
		CompressAString("aaadddooooonnniiiiisssss");
		SecondMostFrequent("Adonis Siempre Avante");
		RotateString("Adonis Siempre Avante", 3);
	}
	
	public static void ImmutableString()
	{
		Console.WriteLine("Once a string object is created, it cannot be changed. Any operation that appears to modify a string actually creates a new string object in memory.");
		string s = "Adonis and Eris";
		s += " Amy";
		Console.WriteLine($"String value: {s}");
	}	

	public static void StringBuilderAndString()
	{
		Console.WriteLine("✅ StringBuilder is mutable, while string is immutable.");
		Console.WriteLine("\nUse string for small or fixed text");
		Console.WriteLine("\nUse StringBuilder for frequent modifications (loos, concatenations)");		

		StringBuilder sb = new("Greeings Adonis");
		sb.Append(" Eris");
	}

	public static void ComparingString()
	{
		string s1 = "Adonis";
		string s2 = "Adonis";
		Console.WriteLine($"object.ReferenceEqueals({s1}, {s2}) = {(object.ReferenceEquals(s1, s2) ? "true": "false")}"  );
	}
	
	public static void NullOrWiteSpace()
	{
		string s = "   ";
		Console.WriteLine($"\nstring.IsNullOrEmpty({s}) = {(string.IsNullOrEmpty(s) ? "true" : "false") })" );
		Console.WriteLine($"string.IsNullOrWhiteSpace({s}) = {(string.IsNullOrWhiteSpace(s) ? "true" : "false") })" );		
	}

	public static void StringComparision()
	{
		Console.WriteLine("\nCompare strings \nAvoids culture issues \nCase-sensitive control \nPrevents bugs");
		Console.WriteLine("string.Equals(a, b, StringComparison.OrdinalIgnoreCase");
	}

	public static void StringReplace()
	{
		string s = "Adonis";
		s.Replace("i", "e");
		Console.WriteLine(s);
	}

	public static void StringOperationsThrow()
	{
		Console.WriteLine("\nWhat exception can string operations throw?");
		Console.WriteLine("\nArgumentOutOfRangeException (e.g., wrong Substring index)");
		Console.WriteLine("\nNullReferenceException (calling methods on null)");		
	}

	public static void Palindrome(string s)
	{
		Console.WriteLine("\n** Palindrome ** ");
		int left = 0, right = s.Length -1 ;
		while (left < right)
		{
			if(s[left] != s[right]) {
				Console.WriteLine($"Is not a palindrome {s}");
				return;
			}
			left++;
			right--;
		}
		Console.WriteLine($"\nIs a Palindrome {s}");
	}

	public static void DetectDuplicates(string s)
	{
		Console.WriteLine("\n** Detect Duplicates **");
 		// https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-10.0
		HashSet<char> seen = [];
		foreach(char c in s)
		{
			if (!seen.Add(c)) 
			{ 
				Console.WriteLine($"Has duplicates {s}"); 
				return;
			}
		}
		Console.WriteLine($"There aren't duplicated {s}");
	}

	public static void ReverseString(string s)
	{
		char[] chars = s.ToCharArray();
		int left = 0, right = chars.Length -1;
		while (left < right)
		{
			(chars[left], chars[right]) = (chars[right], chars[left]);
			left ++;
			right --;
		}
		Console.WriteLine($"Reversed string = {s}");
	}

	public static void CountConcurrences(string s)
	{
		Console.WriteLine($"\nCountConcurrences = {s}");
		Dictionary<char, int> map = [];

		foreach(char c in s)
		{
			if (map.ContainsKey(c))
				map[c]++;
			else
				map[c]=1;
		}
		Console.WriteLine($"map => {map}");
	}

	public static void NonRepeatingChar(string s)
	{
		Console.WriteLine($"\nFind fist non-repeating character of {s}");
		Dictionary<char, int> map = [];

		foreach(char c in s)
			map[c] = map.GetValueOrDefault(c, 0) + 1;

		foreach(char c in s)
		{
			if (map[c] == 1 )
				Console.WriteLine($"{map[c]} = {c}");
		}
	}

	public static void RemoveDuplicated(string s)
	{
		Console.WriteLine($"\nRemove Duplicate Characters = {s}");

		HashSet<char> seen = [];
		StringBuilder sb = new();
		foreach(char c in s)
		{
			if (seen.Add(c))
				sb.Append(c);
		}

		Console.WriteLine($"String without duplicates => {sb}");
	}

	public static void AreAnagrams(string a, string b)
	{
		if (a.Length != b.Length) return;
		
		var count = new Dictionary<char, int>();

		foreach(char c in a)
			count[c] = count.GetValueOrDefault(c, 0) + 1;

		foreach(char c in b)
		{
			if (!count.ContainsKey(c) || --count[c] < 0)
				return;
		}
	}

	public static void FindCommonElement(string[] a, string[] b)
	{
		// ['Adonis', 'Eris', 'Atenea']
		// ['Atenea', 'Amy', 'Vanessa', 'Odiseo', 'Adonis']
		Console.WriteLine("\nFind common elements between two string arrays");
		HashSet<string> set = [.. a];
		List<string> result = [];
		
		foreach(string s in b)
		{
			if (set.Contains(s)) 
				result.Add(s);
		}
	}

	public static void CountVowelsAndConsonants(string s)
	{
		Console.WriteLine("\nCount Vowels And Consonants");
		int v = 0, c = 0;
		HashSet<char> vowels = [.. "aeiouAEIOU"];
		
		foreach(char ch in s)
		{
			if (char.IsLetter(ch))
			{
				if (vowels.Contains(ch)) v++;
				else c++;
			}
		}
		Console.WriteLine($"Vowels {v} and Consonants {c}");
	} 

	public static void CompressAString(string s)
	{
		Console.WriteLine("\nCompress a String");
		StringBuilder sb = new();
		int count = 1;

		for(int i = 1; i <= s.Length; i++)
		{
			if (i == s.Length || s[i] != s[i - 1 ])
			{
				sb.Append(s[i-1]).Append(count);
				count = 1;
			}
			else
				count ++;
		}
		Console.WriteLine($"Comressed String => {sb.ToString()}");
	}

	public static void SecondMostFrequent(string s)
	{
		Console.WriteLine("\nSecond Most Frequent");
		var map = new Dictionary<char, int>();
		foreach(char c in s)
		{
			map[c] = map.GetValueOrDefault(c, 0) + 1;
		}
		Console.WriteLine( map.OrderByDescending(x => x.Value).Skip(1).First().Key);
	}

	public static void RotateString(string s, int k)
	{
		Console.WriteLine("\nRotate String");
		k %= s.Length;
		Console.WriteLine($"\n{s[^k..]} + {s[..^k]} = {s[^k..] + s[..^k]}");
	}
}
