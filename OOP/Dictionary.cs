
namespace C_Sharp
{
	public static class Dictionary
	{
		public static void Dictionaryies() {
      string chain = "abcdefghijklmnopqrstevwxyzz";
      
      for(int i = 0; i < chain.Length; i ++){
        char letter = chain[i];
        for (int c = i+1; c < chain.Length; c++)
            if (letter == chain[c]) {
              Console.WriteLine("Letter repited: " + letter);
            }
      }			

			// Create a Dictionary to track letter counts
			Dictionary<char, int> letterCounts = [];

			// Iterate over the string and count occurrences of each letter
			foreach(char letter in chain){
				if (letterCounts.ContainsKey(letter))
				{
					letterCounts[letter]++;
				}
				else {
					letterCounts[letter] = 1;
				}
			}

			//Display repeated letters
			Console.WriteLine("Repeated Letters:");
			foreach(var pair in letterCounts) {
				 if (pair.Value > 1) {
					Console.WriteLine($"Letter: {pair.Key}, Count: {pair.Value}");
				 }
			}

			// End the Process
			Console.WriteLine("Process Finished!");

	
		}
	}
}