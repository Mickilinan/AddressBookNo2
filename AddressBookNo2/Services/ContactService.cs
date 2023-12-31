
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

//private readonly string filePath;

//public ContactService(string filePath)
//{
//    this.filePath = filePath;
//    LoadContacts(); // Ladda kontakter när tjänsten skapas
//}

//// Lägg till en kontakt i listan
//public void AddContact(Contact contact)
//{
//    if (contacts == null)
//    {
//        contacts = new List<Contact>();
//    }
//    contacts.Add(contact); // Spara kontakter när en ny kontakt läggs till
//}

//public void RemoveContactByEmail(string email)
//{
//    if (contacts != null)
//    {
//        contacts.RemoveAll(c => c.Email == email);
//        SaveContacts();
//    }
//}

//// Ladda kontakter från JSON-filen
//private void LoadContacts()
//{
//    if (File.Exists(filePath))
//    {
//        string json = File.ReadAllText(filePath);
//        contacts = JsonSerializer.Deserialize<List<Contact>>(json);
//    }
//    else
//    {
//        contacts = new List<Contact>();
//    }
//}

//// Spara kontakter till JSON-filen
//private void SaveContacts()
//{
//    string json = JsonSerializer.Serialize(contacts);
//    File.WriteAllText(filePath, json);
//}

//public void UpdateContact(Contact contact)
//{
//    throw new NotImplementedException();
//}

//public List<Contact> GetAllContacts()
//{
//    throw new NotImplementedException();
//}

//public Contact GetContactByEmail(string email)
//{
//    throw new NotImplementedException();
//}
