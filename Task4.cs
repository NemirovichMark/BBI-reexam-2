using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BBI_reexam_2.Task4;

namespace BBI_reexam_2
{
    internal class Task4
    {
        public interface ISerializer
        {
            void WriteToFile(string path, object obj);
            T ReadFromFile<T>(string path);
        }
        public class FolderManager
        {
            private readonly string desktopPath;

            public FolderManager()
            {
                desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            public void CreateFolder(string folderName)
            {
                string folderPath = Path.Combine(desktopPath, folderName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine($"Папка '{folderName}' была успешно создана на рабочем столе.");
                }
                else
                {
                    Console.WriteLine($"Папка '{folderName}' уже существует на рабочем столе.");
                }
            }
            public void CreateFile(string path)
            {
                string filePath = Path.Combine(path, "endReader.json");

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                    Console.WriteLine($"Файл 'endReader.json' был успешно создан по пути: {filePath}");
                }
                else
                {
                    Console.WriteLine($"Файл 'endReader.json' уже существует по пути: {filePath}");
                }
            }
            public void CreateFiles(string path, int count)
            {
                for (int i = 1; i <= count; i++)
                {
                    string fileName = $"endReader_{i}.json";
                    string filePath = Path.Combine(path, fileName);

                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Dispose();
                        Console.WriteLine($"Файл '{fileName}' был успешно создан по пути: {filePath}");
                    }
                    else
                    {
                        Console.WriteLine($"Файл '{fileName}' уже существует по пути: {filePath}");
                    }
                }
            }
        }
        public class EndReaderSerializer : ISerializer
        {
            public void WriteToFile(string path, object obj)
            {
                string jsonString = JsonSerializer.Serialize(obj);
                File.WriteAllText(path, jsonString);
            }
            public T ReadFromFile<T>(string path)
            {
                string jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(jsonString);
            }
        }
        class Program
        {
            static void Main()
            {
                FolderManager folderManager = new FolderManager();
                folderManager.CreateFolder("MyEndReaderFolder");
                string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "MyEndReaderFolder");
                folderManager.CreateFile(folderPath);
                folderManager.CreateFiles(folderPath, 5);
                EndReader endReader = new EndReader("Это пример текста.");
                EndReaderSerializer serializer = new EndReaderSerializer();
                string jsonFilePath = Path.Combine(folderPath, "endReader.json");
                serializer.WriteToFile(jsonFilePath, endReader);
                EndReaderSerializer loadedEndReader = serializer.ReadFromFile<EndReader>(jsonFilePath);

                Console.WriteLine("Загруженный текст:");
                Console.WriteLine(loadedEndReader);
            }
        }
    }
}