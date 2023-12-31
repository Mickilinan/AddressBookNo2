
using AddressBookNo2.Interfaces;
using AddressBookNo2.Models;




namespace AddressBookNo2.Services;

public class ContactService 
{
    private List<Contact> _contacts = [];

    public Contact CurrentContact { get; set; } = null!;

    
    public void Add(Contact contact)
    {
        _contacts.Add(contact);
    }

    public IEnumerable<Contact> GetAll()
    { 
        return _contacts; 
    }   

    public void UpdateContact(Contact updatedContact)
    {
        var contact = _contacts.FirstOrDefault(x => x.Id == updatedContact.Id);
        if (contact != null)
        {
            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Email = updatedContact.Email;
            contact.Phone = updatedContact.Phone;
            contact.Address = updatedContact.Address;
        }
    }
    public void Remove(Contact deletecontact) 
    {
        var contact = _contacts.FirstOrDefault(x => x.Id == deletecontact.Id);    
        if (contact != null) 
        {
            _contacts.Remove(contact);
        }
    }

  

}

