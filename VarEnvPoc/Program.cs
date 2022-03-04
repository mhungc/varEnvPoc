using System;
using Microsoft.Extensions.Configuration;

namespace VarEnvPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
            .AddEnvironmentVariables()
            .Build();

            Settings settings = config.GetRequiredSection("Settings").Get<Settings>();

            Console.WriteLine($"ASPNETCORE_ENVIRONMENT = {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}");
            Console.WriteLine($"KeyOne = {settings.KeyOne}");
            Console.WriteLine($"KeyTwo = {settings.KeyTwo}");
            Console.WriteLine($"KeyThree:Message = {settings.KeyThree.Message}");
        }
    }
}
