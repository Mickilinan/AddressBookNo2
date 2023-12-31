using AddressBookNo2.Models;

namespace AddressBookNo2.Services;

/// <summary>
/// Klass för hantering av kontakter som sparas.
/// </summary>

public class ContactService 
{
    private List<Contact> _contacts = [];

    /// <summary>
    /// Hämtar eller anger den aktuella kontakten för operationer.
    /// </summary>
    public Contact CurrentContact { get; set; } = null!;

    /// <summary>
    /// Lägger till en ny kontakt i minneslistan.
    /// </summary>
    /// <param name="contact">Kontakten som ska läggas till.</param>
    public void Add(Contact contact)
    {
        _contacts.Add(contact);
    }

    /// <summary>
    /// Hämtar alla kontakter från minneslistan.
    /// </summary>
    /// <returns>En uppräkningsbar samling med alla kontakter.</returns>
    public IEnumerable<Contact> GetAll()
    { 
        return _contacts; 
    }

    /// <summary>
    /// Uppdaterar en befintlig kontakt i minneslistan.
    /// </summary>
    /// <param name="updatedContact">Uppdaterad kontaktinformation.</param>
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

