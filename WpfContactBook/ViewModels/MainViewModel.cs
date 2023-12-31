
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace WpfContactBook.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Skapar en ny instans av MainViewModel.
    /// </summary>
    /// <param name="serviceProvider">Service Provider för att hämta andra view models.</param>

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }


    /// <summary>
    /// Den aktuella ViewModel som används i gränssnittet.
    /// </summary>
    [ObservableProperty]
    private ObservableObject currentViewModel = null!;

   
}


