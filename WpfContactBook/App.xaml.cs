
using AddressBookNo2.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WpfContactBook.ViewModels;
using WpfContactBook.Views;

namespace WpfContactBook;


public partial class App : Application
{
    private static IHost? AppHost { get; set; }
    public App()
    {

        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {

             services.AddSingleton<ContactService>();
             services.AddSingleton<JsonFileService>();

             services.AddTransient<AddContactView>();
             services.AddTransient<AddContactViewModel>();

             services.AddTransient<EditContactView>();
             services.AddTransient<EditContactViewModel>();

             services.AddTransient<ContactListView>();
             services.AddTransient<ContactListViewModel>();

                
             services.AddSingleton<MainWindow>();
             services.AddSingleton<MainViewModel>();


            })
            .Build();
        
    }


    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var mainWindow = AppHost!.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

   
}

