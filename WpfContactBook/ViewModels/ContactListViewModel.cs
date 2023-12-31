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

    public ContactListViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;

        Contacts = new ObservableCollection<Contact>(_contactService.GetAll());

    }


    [ObservableProperty]
    private ObservableCollection<Contact> _contacts = [];
   
    
    [RelayCommand]
    private void ShowAddContactView()
    {
        _contactService.CurrentContact = new Contact();

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddContactViewModel>();
    }

    [RelayCommand]
    private void ShowEditContactView(Contact selectedContact)
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<EditContactViewModel>();
    }

    [RelayCommand]
    private void Remove(Contact selectedcontact) 
    {
        _contactService.Remove(selectedcontact);
        Contacts = new ObservableCollection<Contact>(_contactService.GetAll());
    }
}


