using AddressBookNo2.Interfaces;
using AddressBookNo2.Models;
using System.Text.Json;


namespace AddressBookNo2.Services;

public class ContactService : IContactService
{
    private List<Contact>? contacts=null;
    private readonly string filePath;

    public ContactService(string filePath)
    {
        this.filePath = filePath;
        LoadContacts(); // Ladda kontakter när tjänsten skapas
    }

    // Lägg till en kontakt i listan
    public void AddContact(Contact contact)
    {
        if (contacts == null)
        {
            contacts = new List<Contact>();
        }
        contacts.Add(contact); // Spara kontakter när en ny kontakt läggs till
    }

    public void RemoveContactByEmail(string email)
    {
        if (contacts != null)
        {
            contacts.RemoveAll(c => c.Email == email);
            SaveContacts();
        }
    }

    // Ladda kontakter från JSON-filen
    private void LoadContacts()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            contacts = JsonSerializer.Deserialize<List<Contact>>(json);
        }
        else
        {
            contacts = new List<Contact>();
        }
    }

    // Spara kontakter till JSON-filen
    private void SaveContacts()
    {
        string json = JsonSerializer.Serialize(contacts);
        File.WriteAllText(filePath, json);
    }

    public void UpdateContact(Contact contact)
    {
        throw new NotImplementedException();
    }

    public List<Contact> GetAllContacts()
    {
        throw new NotImplementedException();
    }

    public Contact GetContactByEmail(string email)
    {
        throw new NotImplementedException();
    }
}
