using System;
using System.IO;
using System.Text.Json;


abstract class AbstractSerializer
{
    public abstract void WriteObject<T>(string path, T obj);
    public abstract T ReadObject<T>(string path);
}


interface ICreator
{
    void CreateFolder(string folderName);
    void CreateFile(string path);
    void CreateFiles(string path, int count);
}


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


class CounterSerializer : AbstractSerializer, ICreator
{
    public override void WriteObject<T>(string path, T obj)
    {
        try
        {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи объекта в файл: {ex.Message}");
        }
    }

    public override T ReadObject<T>(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при чтении объекта из файла: {ex.Message}");
            return default;
        }
    }

    public void CreateFolder(string folderName)
    {
        try
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), folderName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании папки: {ex.Message}");
        }
    }

    public void CreateFile(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
        }
    }

    public void CreateFiles(string path, int count)
    {
        try
        {
            for (int i = 1; i <= count; i++)
            {
                string filePath = Path.Combine(path, $"counter_{i}.json");
                CreateFile(filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании файлов: {ex.Message}");
        }
    }
}

class Program
{
    static void Main()
    {

        Counter counter = new Counter("Nº1,2 and 30, -4");
        CounterSerializer serializer = new CounterSerializer();

        string folderName = "Counters";
        serializer.CreateFolder(folderName);

        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), folderName);
        string filePath = Path.Combine(folderPath, "counter.json");


        Counter loadedCounter = serializer.ReadObject<Counter>(filePath);
        if (loadedCounter != null)
        {
            Console.WriteLine(loadedCounter.ToString());
        }
    }
}