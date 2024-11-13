using System;
namespace BBI_reexam_2
{
    internal class Task3
    {
        public Task3()
        { }
         

public class Personal
        {
            private string input;
            private string[] output;

            
            public string Input => input;

           
            public string[] Output => output;

            
            public Personal(string text)
            {
                input = text;
                ExtractProperNouns();
            }

           
            private void ExtractProperNouns()
            {
              
                string[] words = input.Split(new char[] { ' ', 'n', 'r', ',', '.', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                
                int count = 0;
                foreach (string word in words)
                {
                    if (word.Length > 0 && char.IsUpper(word[0]))
                    {
                        count++;
                    }
                }

               
                output = new string[count];
                int index = 0;

              
                foreach (string word in words)
                {
                    if (word.Length > 0 && char.IsUpper(word[0]))
                    {
                        output[index++] = word;
                    }
                }
            }

            
            public override string ToString()
            {
                if (output == null || output.Length == 0)
                {
                    return "Нет найденных имен собственных.";
                }

                string result = "";
                foreach (string name in output)
                {
                    result += name + Environment.NewLine; 
                }
                return result.Trim(); 
            }
        }

        
        public class Program
        {
            public static void Main()
            {
                string text = "В этом тексте есть имена: Анна, Борис, и Екатерина. Также есть другие слова.";

                Personal personal = new Personal(text);

                Console.WriteLine("Входная строка:");
                Console.WriteLine(personal.Input);

                Console.WriteLine("nНайденные имена собственные:");
                Console.WriteLine(personal.ToString());

            }
        }

    }
}

