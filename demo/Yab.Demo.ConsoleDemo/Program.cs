using Microsoft.Extensions.Hosting;
using System;
using System.Transactions;

namespace Yab.Demo.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).RunConsoleAsync();
                Console.WriteLine("已启动");
                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine("启动失败");
                Console.WriteLine(ex.Message);
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {

            })
            .ConfigureServices((context, services) =>
            {

            });
    }
}
