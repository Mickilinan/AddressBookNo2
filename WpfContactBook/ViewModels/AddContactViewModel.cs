

using AddressBookNo2.Interfaces;
using AddressBookNo2.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfContactBook.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    public AddContactViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
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

    //public IRelayCommand AddContactCommand => new RelayCommand(AddContact);
    [RelayCommand]
    private void AddContact()
    {
        if (!string.IsNullOrWhiteSpace(FirstName) &&
            !string.IsNullOrWhiteSpace(LastName) &&
            !string.IsNullOrWhiteSpace(Phone) &&
            !string.IsNullOrWhiteSpace(Email) &&
            !string.IsNullOrWhiteSpace(Address))
        {
            var newContact = new Contact
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Email = Email,
                Address = Address
            };

            _contactService.AddContact(newContact);
            // Lägg till logik här för att navigera till en annan vy om så önskas
        }
        else
        {
            // Lägg till logik för att hantera fel här
        }
    }
}

