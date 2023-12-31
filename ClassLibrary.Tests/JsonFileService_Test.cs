

using AddressBookNo2.Models;
using AddressBookNo2.Services;
using System.Text.Json;

namespace ClassLibrary.Tests;

public class JsonFileService_Test : IDisposable
{


    private readonly string _testFilePath = "test-contacts.json"; 

    public JsonFileService_Test()
    {
        // Initiera och rensa filen innan varje test
        File.WriteAllText(_testFilePath, "[]");
    }

    public void Dispose()
    {
       
        File.Delete(_testFilePath);
    }

    [Fact]
    public void AddContact_ShouldAddContactToFile()
    {
        // Arrange
        var service = new JsonFileService(_testFilePath);
        var contact = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Phone = "123-456-7890",
            Address = "123 Main St"
        };

        // Act
        service.AddContact(contact);

        // Assert
        var savedContacts = ReadContactsFromTestFile();
        Assert.Single(savedContacts); 
        Assert.Equal(contact.Email, savedContacts[0].Email); 
    }

    [Fact]
    public void UpdateContact_ShouldUpdateContactInFile()
    {
        // Arrange
        var service = new JsonFileService(_testFilePath);
        var originalContact = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Phone = "123-456-7890",
            Address = "123 Main St"
        };
        var updatedContact = new Contact
        {
            FirstName = "Updated",
            LastName = "Doe",
            Email = "john@example.com", 
            Phone = "555-555-5555",
            Address = "456 Updated St"
        };
        service.AddContact(originalContact);

        // Act
        service.UpdateContact(updatedContact);

        // Assert
        var savedContacts = ReadContactsFromTestFile();
        Assert.Single(savedContacts); 
        Assert.Equal(updatedContact.FirstName, savedContacts[0].FirstName); 
        Assert.Equal(updatedContact.Phone, savedContacts[0].Phone);
        Assert.Equal(updatedContact.Address, savedContacts[0].Address);
    }

    [Fact]
    public void RemoveContactByEmail_ShouldRemoveContactFromFile()
    {
        // Arrange
        var service = new JsonFileService(_testFilePath);
        var contactToRemove = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Phone = "123-456-7890",
            Address = "123 Main St"
        };
        service.AddContact(contactToRemove);

        // Act
        service.RemoveContactByEmail(contactToRemove.Email);

        // Assert
        var savedContacts = ReadContactsFromTestFile();
        Assert.Empty(savedContacts); 
    }

    [Fact]
    public void GetAllContacts_ShouldReturnAllContactsFromFile()
    {
        // Arrange
        var service = new JsonFileService(_testFilePath);
        var contact1 = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Phone = "123",
            Address = "123"
        };
        var contact2 = new Contact
        {
            FirstName = "Jane",
            LastName = "Doe",
            Email = "jane@example.com",
            Phone = "123",
            Address = "456"
        };
        service.AddContact(contact1);
        service.AddContact(contact2);

        // Act
        var retrievedContacts = service.GetAllContacts();

        // Assert
        Assert.Equal(2, retrievedContacts.Count); 
        Assert.Contains(contact1, retrievedContacts); 
        Assert.Contains(contact2, retrievedContacts);
    }

    [Fact]
    public void GetContactByEmail_ShouldReturnContactFromFile()
    {
        // Arrange
        var service = new JsonFileService(_testFilePath);
        var contactToRetrieve = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@example.com",
            Phone = "123",
            Address = "123"
        };
        service.AddContact(contactToRetrieve);

        // Act
        var retrievedContact = service.GetContactByEmail(contactToRetrieve.Email);

        // Assert
        Assert.NotNull(retrievedContact); 
        Assert.Equal(contactToRetrieve, retrievedContact); 
    }

    
    private List<Contact> ReadContactsFromTestFile()
    {
        var json = File.ReadAllText(_testFilePath);
        return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
    }
}


