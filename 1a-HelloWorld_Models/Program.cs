using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityFramework = new DataContextEF(config);


            string sqlCommand = "SELECT GETDATE()";
            DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);
            Console.WriteLine(rightNow);



            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060",
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

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

            Console.WriteLine(sql);


            bool result = dapper.ExecuteSql(sql);


            string sqlSelect = @"
            SELECT 
                Computer.ComputerId,
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
            FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);
            foreach (Computer computer in computers)
            {
                Console.WriteLine($@"
                {computer.ComputerId},
                {computer.Motherboard},
                {computer.HasWifi},
                {computer.HasLTE},
                {computer.ReleaseDate},
                {computer.Price},
                {computer.VideoCard}
                ");
            }

            IEnumerable<Computer>? computersEf = entityFramework.Computer?.ToList<Computer>();
            if (computersEf != null)
            {
                foreach (Computer computer in computersEf)
                {
                    Console.WriteLine($@"
                {computer.ComputerId},
                {computer.Motherboard},
                {computer.HasWifi},
                {computer.HasLTE},
                {computer.ReleaseDate},
                {computer.Price},
                {computer.VideoCard}
                ");
                }
            }

            IEnumerable<Computer>? computersEfWithCPUCores = entityFramework.Computer?.Where(c => c.CPUCores != null).ToList<Computer>();

            int noOfComputersWithCPUCores = computersEfWithCPUCores.Count();
            Console.WriteLine($"Amount of computers with CPUCores: {noOfComputersWithCPUCores}");


            //myComputer.HasWifi = false;

            //Console.WriteLine(myComputer.Motherboard);
            //Console.WriteLine(myComputer.HasWifi);
            //Console.WriteLine(myComputer.ReleaseDate);
            //Console.WriteLine(myComputer.VideoCard);


        }
    }
}