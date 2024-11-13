using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
	internal class Task3
	{
		public Task3()
		{
			Counter counter = new Counter("Это текст с 123 цифрами и знаками препинания: , . ! ?");
			Console.WriteLine(counter);
		}
	}
	public class Counter
	{
		private string _input;
		private int[] _output;

		public string Input
		{
			get { return _input; }
		}

		public int[] Output
		{
			get { return _output; }
		}
		public Counter(string text)
		{
			_input = text;
			_output = new int[3];

			CountCharacters();
		}
		private void CountCharacters()
		{
			HashSet<char> letters = new HashSet<char>();
			HashSet<char> digits = new HashSet<char>();
			HashSet<char> punctuation = new HashSet<char>();

			foreach (char c in _input)
			{
				if (char.IsLetter(c))
				{
					letters.Add(char.ToLower(c));
				}
				else if (char.IsDigit(c))
				{
					digits.Add(c);
				}
				else if (char.IsPunctuation(c))
				{
					punctuation.Add(c);
				}
			}
			_output[0] = letters.Count;
			_output[1] = digits.Count;
			_output[2] = punctuation.Count;
		}
		public override string ToString()
		{
			return $"Букв/Цифр/Знаков препинания в тексте = {_output[0]}/{_output[1]}/{_output[2]}";
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Task3 task3 = new Task3();
			Console.ReadKey();
		}
	}
}
