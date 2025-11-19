namespace C_Sharp
{
	public static class StringRepeated
	{

		public static bool IsFoundIt(string text)
		{
			bool FoundIt = false;
      for(int i = 0; i < text.Length; i++)
      {
        var pivotLetter = text[i];
        for(int p = i+1; p < text.Length; p++)
        {
          if (pivotLetter == text[p]) { return true;  }
        }
        if (FoundIt) break;
      }
      return FoundIt;					
		}


		public static void GetStringRepeted()
		{
      string text="Julio Esteban Ochoa Perez";
			var result = IsFoundIt(text);
			Console.WriteLine("Found it = {0}", result ? "True": "False");

      char[] characters = text.ToCharArray();
      Array.Sort(characters);
      string sortedString = new(characters);
			result = IsFoundIt(sortedString.Trim().ToLower());
			Console.WriteLine("Found it = {0}", result ? "True": "False");			
 		}
	}
}
