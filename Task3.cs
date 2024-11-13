using System;
using System.Linq;

class Counter
{
    public string Input { get; }
    public double Output { get; private set; }

    public Counter(string input)
    {
        Input = input;
        CalculateAverage();
    }

    private void CalculateAverage()
    {
        var digits = Input.Where(char.IsDigit).Select(c => (double)(c - '0')).ToArray();
        Output = digits.Length > 0 ? digits.Average() : 0;
    }

    public override string ToString() => $"Average of digits: {Output:F2}";
}

class Program
{
    static void Main()
    {
        Counter counter = new Counter("Nº1,2 and 30, -4");
        Console.WriteLine(counter.ToString());
    }
}