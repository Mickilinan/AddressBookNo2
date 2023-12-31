
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfContactBook.ViewModels;


namespace WpfContactBook;


public partial class MainWindow : Window
{
    public MainWindow(IServiceProvider  serviceProvider)
    {
        InitializeComponent();
        DataContext = serviceProvider.GetRequiredService<MainViewModel>();
    }

   
}