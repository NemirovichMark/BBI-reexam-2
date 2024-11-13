using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task3
    {


        public struct Cipher
        {
            public string Input { get; set; }
            public string Output { get; set; }

            public static Cipher Create(string input)
            {
                Cipher cipher = default;
                cipher.Input = input;
                cipher.Output = Encrypt(input);
                return cipher;
            }

            private static string Encrypt(string text)
            {
                StringBuilder result = new StringBuilder();
                const string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

                for (int i = 0; i < text.Length; i++)
                {
                    char c = text[i];
                    if (Char.IsLetter(c))
                    {
                        int index = Char.ToLower(c) - 'а';
                        int newIndex = (index + 5) % 32;
                        if (Char.IsUpper(c))
                            result.Append(russianAlphabet[newIndex].ToString().ToUpper());
                        else
                            result.Append(russianAlphabet[newIndex]);
                    }
                    else
                        result.Append(c);
                }

                return result.ToString();
            }

            public override string ToString()
            {
                return $"Input: {Input}\nOutput: {Output}";
            }
        }
    }
}
   