using forms = System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HardkorowyKodsu.Infrastructure;
using HardkorowyKodsu.Client.ViewModels;

namespace HardkorowyKodsu.Client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            forms.Application.EnableVisualStyles();
            forms.Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            forms.Application.Run(host.Services.GetRequiredService<MainForm>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddInfrastructure();
                    services.AddScoped<DatabaseViewModel>();
                    services.AddTransient<MainForm>();
                });
        }
    }
}