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
            string inputText = "Привет, как твои дела. Посмотри мне в глаза, не бойся";
            Reverser reverser = new Reverser(inputText);
            Console.WriteLine(reverser.ToString());
        }
        public class Reverser
        {
            private string input;
            private string output;
            public string Input => input;
            public string Output => output;

            public Reverser(string text)
            {
                input = text;
                output = ReverseWords(input);
            }
            private string ReverseWords(string text)
            {
                char[] result = new char[text.Length];
                int wordStart = -1;

                for (int i = 0; i < text.Length; i++)
                {
                    if (char.IsLetterOrDigit(text[i]))
                    {
                        if (wordStart == -1)
                        {
                            wordStart = i;
                        }
                    }
                    else
                    {
                        if (wordStart != -1)
                        {
                            int wordEnd = i - 1;
                            for (int j = wordStart, k = wordEnd; j <= wordEnd; j++, k--)
                            {
                                result[j] = text[k];
                            }
                            wordStart = -1;
                        }
                        result[i] = text[i];
                    }
                }
                if (wordStart != -1)
                {
                    int wordEnd = text.Length - 1;
                    for (int j = wordStart, k = wordEnd; j <= wordEnd; j++, k--)
                    {
                        result[j] = text[k];
                    }
                }
                return new string(result);
            }
            public override string ToString()
            {
                return Output;
            }
        }
    }
}