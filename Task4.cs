using System;
using System.IO;
using System.Text.Json;
namespace BBI_reexam_2
{
    internal class Task4
    {
        public Task4()
        { }

        public interface ISerializer
        {
            void Serialize(string path, Personal personal);
            Personal Deserialize(string path);
        }

        public class CommonSerializer
        {
            private string userFolderPath;

            public CommonSerializer()
            {
                userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            public void CreateFolder(string folderName)
            {
                string folderPath = Path.Combine(userFolderPath, folderName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }

            public void CreateFile(string filePath)
            {
                using (File.Create(filePath)) { }
            }

            public void CreateFiles(string folderPath, int fileCount)
            {
                for (int i = 1; i <= fileCount; i++)
                {
                    string fileName = $"personal_{i}.json";
                    string fullPath = Path.Combine(folderPath, fileName);
                    CreateFile(fullPath);
                }
            }

            public string UserFolderPath => userFolderPath;
        }

        public class JSONSerializer : ISerializer
        {
            public void Serialize(string path, Personal personal)
            {
               
                string jsonString = JsonSerializer.Serialize(personal);
                File.WriteAllText(path, jsonString);
            }

            public Personal Deserialize(string path)
            {
              
                string jsonString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<Personal>(jsonString);
            }
        }

        public class Personal
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class Program
        {
            public static void Main()
            {
                CommonSerializer commonSerializer = new CommonSerializer();

                string folderName = "MyPersonalData";
                commonSerializer.CreateFolder(folderName);

                JSONSerializer jsonSerializer = new JSONSerializer();

                Personal personal = new Personal { Name = "Анна", Age = 30 };

                string personalJsonPath = Path.Combine(commonSerializer.UserFolderPath, folderName, "personal.json");

                jsonSerializer.Serialize(personalJsonPath, personal);

                Personal deserializedPersonal = jsonSerializer.Deserialize(personalJsonPath);

                Console.WriteLine($"Имя: {deserializedPersonal.Name}, Возраст: {deserializedPersonal.Age}");

                commonSerializer.CreateFiles(Path.Combine(commonSerializer.UserFolderPath, folderName), 5);

            }
        }
    }
}
