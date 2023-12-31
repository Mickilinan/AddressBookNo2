

using AddressBookNo2.Interfaces;
using AddressBookNo2.Models;
using AddressBookNo2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace WpfContactBook.ViewModels;

public partial class EditContactViewModel : ObservableObject
{
     private readonly IServiceProvider _serviceProvider;
    private readonly ContactService _contactService;

    [ObservableProperty]
    private Contact contact = new();
    public EditContactViewModel(IServiceProvider serviceProvider, ContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;

        Contact = _contactService.CurrentContact;
    }
    private string _firstName = string.Empty;
    private string _lastName = string.Empty;
    private string _phone = string.Empty;
    private string _email = string.Empty;
    private string _address = string.Empty;

    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    public string Phone
    {
        get => _phone;
        set => SetProperty(ref _phone, value);
    }

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string Address
    {
        get => _address;
        set => SetProperty(ref _address, value);
    }




    [RelayCommand]
    private void UpdateContact()
    {
        Contact.FirstName = FirstName;
        Contact.LastName = LastName;
        Contact.Email = Email;
        Contact.Phone = Phone;
        Contact.Address = Address;

        _contactService.UpdateContact(Contact);

      var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>(); 
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactListViewModel>();
    }
}

