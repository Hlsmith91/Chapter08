using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter08
{
	class Program
	{
		static void Main(string[] args)
		{
			//Using a stack
			//https://docs.microsoft.com/en-us/dotnet/api/
			//system.collectios.generic.stack-1?
			//view = netframework-4.7.2


			//IsPalindrome();
			//GenericDictionary();
			//FindDuplicates();

			int[] missingValues = { 25, 1, 5, 10, 15, 20 };
			int[] whatsNotThere = new int[missingValues.Max()];
			Dictionary<int, int> everybody = new Dictionary<int, int>();


			for (int i = missingValues.Min(); i < missingValues.Max(); i++)
			{
                everybody.Add(i, 0);

                if (missingValues.Contains(i))
				{
                    everybody.Remove(i);
				}
			}
            Console.WriteLine("Missing Numbers: ");
		    foreach(var key in everybody)
            {
                Console.WriteLine(key.Key);
            }


				Console.ReadKey();

		}

		private static void FindDuplicates()
		{
			int[] dupValues = { 1, 2, 3, 3, 3, 4, 4, 5, 6, 7, 8, 1, 1, 1, 1, 20 };
			Dictionary<int, int> dict = new Dictionary<int, int>();
			for (int i = 0; i < dupValues.Length; i++)
			{
				try
				{
					dict.Add(dupValues[i], 1);
				}
				catch
				{
					dict[dupValues[i]]++;
				}
			}
		}

		private static void GenericDictionary()
		{
			Dictionary<string, string> executeableProgram = new Dictionary<string, string>();
			executeableProgram.Add("pdf", "acrord32.exe");
			executeableProgram.Add("tif", "snagit32.exe");
			executeableProgram.Add("jpg", "snagit32.exe");
			executeableProgram.Add("sln", "devenv.exe");
			executeableProgram.Add("rtf", "wordpad.exe");

			Console.WriteLine("For key: = \"rtf\", value = {0}", executeableProgram["rtf"]);

			try
			{

				executeableProgram.Add("rtf", "winword.exe");

			}
			catch (ArgumentException exc)
			{
				Console.WriteLine("An element with key \"txt\" already exists.");
				Console.WriteLine(exc.Message);
			}
			foreach (KeyValuePair<string, string> kvp in executeableProgram)
			{
				Console.WriteLine(kvp.Key + " " + kvp.Value);
			}
		}


		private static void IsPalindrome()
		{
			string input = "";

			Console.WriteLine("Enter a string:");

			input = Console.ReadLine();

			string printInput = input;
			input.ToLower();
			Regex rgx = new Regex("[^a-zA-Z0-9]");
			input = rgx.Replace(input, "");
			char[] ch = input.ToCharArray();
			Stack<char> stack = new Stack<char>();
			for (int i = 0; i < ch.Length; i++)
			{
				stack.Push(ch[i]);
			}

			String reverseString = "";

			while (stack.Count > 0)
			{
				reverseString = reverseString + stack.Pop();
			}


			if (input.Equals(reverseString))
			{
				Console.WriteLine(printInput + "\n is a palindrome");
			}
			else
			{

				Console.WriteLine(printInput + "\n is NOT a palindrome");
			}
		}
	}
}
