using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileHandling
{
    internal class FileHandle
    {

        public void FileHandlingConcept()
        {
            

            try
            {
                File.Create("test.txt").Close();
                File.WriteAllText("test.txt", "Hello World what are doing ??");
                File.AppendAllText("test.txt", "I am learning C#");
                string content = File.ReadAllText("test.txt");
                Console.WriteLine(content);

                File.Copy("test.txt", "test_copy.txt");

                using(StreamReader reader = new StreamReader("test_copy.txt"))
                {
                    string line;
                    while((line = reader.ReadLine())!= null)
                    {
                        Console.WriteLine(line);
                    }
                }

                //File.Delete("test.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}