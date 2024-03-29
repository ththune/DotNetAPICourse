using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060",
            };

            string sql = $@"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES (
                '{myComputer.Motherboard}',
                '{myComputer.HasWifi}',
                '{myComputer.HasLTE}',
                '{myComputer.ReleaseDate}',
                '{myComputer.Price}',
                '{myComputer.VideoCard}'
            )";

            //File.WriteAllText("log.txt", sql);

            using StreamWriter openFile = new StreamWriter("log.txt", append: true);
            openFile.WriteLine(sql);
            openFile.Close();

            String fileText = File.ReadAllText("log.txt");
            Console.WriteLine(fileText);

            //Console.WriteLine(File.ReadAllText("log.txt"));
        }
    }
}