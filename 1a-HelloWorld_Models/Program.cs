using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json;

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

            string computersJson = File.ReadAllText("Computers.json");
            //Console.WriteLine(computersJson);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };


            IEnumerable<Computer>? computersNewtonsoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);



            if (computersNewtonsoft != null)
            {
                foreach (Computer computer in computersNewtonsoft)
                {
                    //Console.WriteLine(computer.Motherboard);
                    string sql = $@"INSERT INTO TutorialAppSchema.Computer (
                        Motherboard,
                        HasWifi,
                        HasLTE,
                        ReleaseDate,
                        Price,
                        VideoCard
                    ) VALUES (
                        '{EscapeSingleQuote(computer.Motherboard)}',
                        '{computer.HasWifi}',
                        '{computer.HasLTE}',
                        '{computer.ReleaseDate}',
                        '{computer.Price}',
                        '{EscapeSingleQuote(computer.VideoCard)}'
                    )";

                    Console.WriteLine(sql);

                    dapper.ExecuteSql(sql);
                }
            }

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonsoft, settings);
            File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);

            string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
            File.WriteAllText("computersCopySystem.txt", computersCopySystem);


            //string sql = $@"INSERT INTO TutorialAppSchema.Computer (
            //    Motherboard,
            //    HasWifi,
            //    HasLTE,
            //    ReleaseDate,
            //    Price,
            //    VideoCard
            //) VALUES (
            //    '{myComputer.Motherboard}',
            //    '{myComputer.HasWifi}',
            //    '{myComputer.HasLTE}',
            //    '{myComputer.ReleaseDate}',
            //    '{myComputer.Price}',
            //    '{myComputer.VideoCard}'
            //)";

            //File.WriteAllText("log.txt", sql);

            //using StreamWriter openFile = new StreamWriter("log.txt", append: true);
            //openFile.WriteLine(sql);
            //openFile.Close();

            //String fileText = File.ReadAllText("log.txt");
            //Console.WriteLine(fileText);

            //Console.WriteLine(File.ReadAllText("log.txt"));
        }

        static string EscapeSingleQuote(string input)
        {
            string output = input.Replace("'", "''");

            return output;
        }
    }
}