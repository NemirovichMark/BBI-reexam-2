using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task3
    {
            class EndReader
        {
            private string input;
            private string[] output;

            public string Input => input;
            public string[] Output => output;
            public EndReader(string text)
            {
                input = text;
                ExtractLastWords();
            }
            private void ExtractLastWords()
            {
                var sentences = input.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(s => s.Trim())
                                     .ToArray();
                output = sentences.Select(s => s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                 .LastOrDefault())
                                  .ToArray();
            }
            public override string ToString()
            {
                return string.Join(Environment.NewLine, output.Where(word => word != null));
            }
        }

        class Program
        {
            static void Main()
            {
                string inputText = "Это первое предложение. Вот второе! А это третье?";
                EndReader endReader = new EndReader(inputText);

                Console.WriteLine("Входная строка:");
                Console.WriteLine(endReader.Input);
                Console.WriteLine("nПоследние слова предложений:");
                Console.WriteLine(endReader.ToString());
            }
        }
    }
}
