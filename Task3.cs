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
public class Capital
{
    private string input;
    private List<string> output;

    public Capital(string inputText)
    {
        input = inputText;
        output = new List<string>();
        FindMostFrequentCapitalLetterAndWords();
    }

    public string Input => input;

    public List<string> Output => output;

    private void FindMostFrequentCapitalLetterAndWords()
    {
        var capitalLetters = input.Where(char.IsUpper).ToList();

        if (capitalLetters.Any())
        {
            var mostFrequentLetter = capitalLetters
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;

            output = input
                .Split(new[] { ' ', '.', ',', ';', ':', '!', '?', '-', '(', ')', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word.StartsWith(mostFrequentLetter.ToString(), StringComparison.Ordinal))
                .ToList();
        }
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, output);
    }
}
class Programmm
{
    static void Main()
    {
        string inputText = "АНКАРА, 13 ноября. /ТАСС/. Турция получила от БРИКС предложение стать государством-партнером, ассоциированным членом объединения. Об этом заявил министр торговли республики Омер Болат.\r\n\r\n\"БРИКС - это организация сотрудничества, в нее входят важные страны, на долю которых приходится 25% мирового ВВП. Популярность БРИКС растет. Что касается присоединения Турции к БРИКС, то нам было предложено ассоциированное членство. Вступление в БРИКС принесет Турции значительную выгоду с точки зрения сотрудничества со всеми важными мировыми платформами\", - приводит слова Болата телеканал haber.\r\n\r\nМинистр напомнил, что на последнем саммите БРИКС в Казани \"рассматривалась заявки Турции и некоторых других стран\". \"Как мы понимаем, нам предлагают статус партнера. При этом нет речи о том, чтобы Индия наложила вето на наше членство\", - добавил Болат.\r\n\r\nОн напомнил, что в БРИКС в различных статусах входят \"страны Африки, Персидского залива, Ближнего Востока и Азии\", а цель Турции \"развивать многомерные и многоуровневые отношения на площадке объединения как в сфере внешней политики, так и в торгово-экономической сфере\"..";
        Capital capital = new Capital(inputText);

        Console.WriteLine("Input text:");
        Console.WriteLine(capital.Input);

        Console.WriteLine("\nСлова:");
        Console.WriteLine(capital.ToString());
    }
}
