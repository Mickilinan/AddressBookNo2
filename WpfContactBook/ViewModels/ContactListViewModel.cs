using AddressBookNo2.Models;
using AddressBookNo2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace WpfContactBook.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ContactService _contactService;
    /// <summary>
    /// Skapar en ny instans av ContactListViewModel.
    /// </summary>
    /// <param name="serviceProvider">Service Provider för att hämta andra view models.</param>
    /// <param name="contactService">ContactService för att hantera kontakter.</param>
    public ContactListViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;

        Contacts = new ObservableCollection<Contact>(_contactService.GetAll());

    }

    /// <summary>
    /// En kollektion av kontakter som visas i kontaktlistan.
    /// </summary>
    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = [];


    /// <summary>
    /// Visar vyn för att lägga till en ny kontakt.
    /// </summary>
    [RelayCommand]
    private void ShowAddContactView()
    {
        _contactService.CurrentContact = new Contact();

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddContactViewModel>();
    }


    /// <summary>
    /// Visar vyn för att redigera en kontakt.
    /// </summary>
    /// <param name="selectedContact">Den valda kontakten som ska redigeras.</param>
    [RelayCommand]
    private void ShowEditContactView(Contact selectedContact)
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditContactViewModel>();
    }


    /// <summary>
    /// Tar bort en kontakt och uppdaterar kontaktlistan.
    /// </summary>
    /// <param name="selectedcontact">Den valda kontakten som ska tas bort.</param>
    [RelayCommand]
    private void Remove(Contact selectedcontact) 
    {
        _contactService.Remove(selectedcontact);
        Contacts = new ObservableCollection<Contact>(_contactService.GetAll());
    }
}


