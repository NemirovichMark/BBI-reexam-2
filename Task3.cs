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

        }
    }
}


class Reverser
{
    public string Input { get; private set; } 
    public string Output { get; private set; } 
    public Reverser(string input)
    {
        Input = input;
        Output = ReverseSentences(Input);
    }

    private string ReverseSentences(string input)
    {
        string[] sentences = input.Split(new[] { '.', '?', '!' }, StringSplitOptions.None);

        string result = "";
        for (int i = 0; i < sentences.Length; i++)
        {
            if (i < sentences.Length - 1)
            {
                char endChar = input[sentences[i].Length + i]; 
                result = sentences[i].Trim() + endChar + " " + result;
            }
            else
            {
                result = sentences[i].Trim() + result;
            }
        }
        return result.Trim(); 
    }

    public override string ToString()
    {
        return Output;
    }
}

class Program
{
    static void Main()
    {
        string inputText = "Hello world! How are you? Have a great day.";

        Reverser reverser = new Reverser(inputText);

        Console.WriteLine("Входной текст: ");
        Console.WriteLine(reverser.Input);
        Console.WriteLine("\nРезультат (тексты предложений задом наперёд):");
        Console.WriteLine(reverser);
    }
}
