using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace VoiceTexterBot
{
    public class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services)) 
                .UseConsoleLifetime() 
                .Build();

            Console.WriteLine("Сервис запущен");
            
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)        {
            
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("6190187242:AAGo97DWjHJ-FMa-vKDruEd_CJOuO8f_zYA"));
            
            services.AddHostedService<Bot>();
        }
    }
}