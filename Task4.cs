using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBI_reexam_2
{
    internal class Task4
    {
        public abstract class AbstractSerializer
        {
            public abstract void WriteObject(string path, object obj);
            public abstract T ReadObject<T>(string path) where T : class;
        }

        public class CipherSerializer : AbstractSerializer
        {
            public override void WriteObject(string path, object obj)
            {
                var json = JsonConvert.SerializeObject(obj);
                File.WriteAllText(path, json);
            }

            public override T ReadObject<T>(string path) where T : class
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public interface ICreator
        {
            void CreateFolder(string folderName);
            void CreateFile(string filePath);
            void CreateFiles(string directoryPath, int numberOfFiles);
        }

        public class FileCreator : ICreator
        {
            public void CreateFolder(string folderName)
            {
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.Downloads);
                string fullPath = Path.Combine(downloadsPath, folderName);

                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
            }

            public void CreateFile(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                }
            }

            public void CreateFiles(string directoryPath, int numberOfFiles)
            {
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.Downloads);
                string fullPath = Path.Combine(downloadsPath, directoryPath);

                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }

                for (int i = 1; i <= numberOfFiles; i++)
                {
                    string fileName = $"cipher_{i}.json";
                    string filePath = Path.Combine(fullPath, fileName);

                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Dispose();
                    }
                }
            }
        }
    }
}