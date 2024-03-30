using AutoMapper;
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

            string computersJson = File.ReadAllText("ComputersSnake.json");
            //string computersJson = File.ReadAllText("Computers.json");


            //Mapper mapper = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ComputerSnake, Computer>()
            //    .ForMember(destination => destination.ComputerId, options =>
            //        options.MapFrom(source => source.computer_id))
            //    .ForMember(destination => destination.Motherboard, options =>
            //        options.MapFrom(source => source.motherboard))
            //    .ForMember(destination => destination.CPUCores, options =>
            //        options.MapFrom(source => source.cpu_cores))
            //    .ForMember(destination => destination.HasWifi, options =>
            //        options.MapFrom(source => source.has_wifi))
            //    .ForMember(destination => destination.HasLTE, options =>
            //        options.MapFrom(source => source.has_lte))
            //    .ForMember(destination => destination.ReleaseDate, options =>
            //        options.MapFrom(source => source.release_date))
            //    .ForMember(destination => destination.Price, options =>
            //        options.MapFrom(source => source.price))
            //    .ForMember(destination => destination.VideoCard, options =>
            //        options.MapFrom(source => source.video_card));
            //}));

            IEnumerable<Computer>? computersSystemJsonPropertyMapping = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);

            if (computersSystemJsonPropertyMapping != null)
            {
                foreach (Computer computer in computersSystemJsonPropertyMapping)
                {
                    Console.WriteLine(computer.Motherboard);
                }
            }


            //IEnumerable<ComputerSnake>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);

            //if (computersSystem != null)
            //{
            //    IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystem);

            //    foreach (Computer computer in computerResult)
            //    {
            //        Console.WriteLine(computer.Motherboard);
            //    }
            //}


            //Mapper mapper2 = new Mapper(new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ComputerSnake, Computer>()
            //    .ForAllMembers(destination => des);
            //}));

            //Console.WriteLine(computersJson);

            //IEnumerable<Computer>? computersNewtonsoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            //JsonSerializerOptions options = new JsonSerializerOptions()
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //};

            //IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);



            //if (computersNewtonsoft != null)
            //{
            //    foreach (Computer computer in computersNewtonsoft)
            //    {
            //        //Console.WriteLine(computer.Motherboard);
            //        string sql = $@"INSERT INTO TutorialAppSchema.Computer (
            //            Motherboard,
            //            HasWifi,
            //            HasLTE,
            //            ReleaseDate,
            //            Price,
            //            VideoCard
            //        ) VALUES (
            //            '{EscapeSingleQuote(computer.Motherboard)}',
            //            '{computer.HasWifi}',
            //            '{computer.HasLTE}',
            //            '{computer.ReleaseDate}',
            //            '{computer.Price}',
            //            '{EscapeSingleQuote(computer.VideoCard)}'
            //        )";

            //        Console.WriteLine(sql);

            //        dapper.ExecuteSql(sql);
            //    }
            //}

            //JsonSerializerSettings settings = new JsonSerializerSettings()
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //};

            //string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonsoft, settings);
            //File.WriteAllText("computersCopyNewtonsoft.txt", computersCopyNewtonsoft);

            //string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
            //File.WriteAllText("computersCopySystem.txt", computersCopySystem);


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