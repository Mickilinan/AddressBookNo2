using AddressBookNo2.Interfaces;
using AddressBookNo2.Models;
using AddressBookNo2.Services;


namespace ConsoleBook;

public class Program
{
    private static IContactService _contactService; // Du behöver en instans av ContactService

        public static void Main(string[] args)
        {
            // Ange sökvägen till din JSON-fil här
            string filePath = "contacts.json";
            _contactService = new JsonFileService(filePath);

            while (true)
            {
                Console.WriteLine("Välkommen till Adressbok!");
                Console.WriteLine("1. Lägg till en kontakt");
                Console.WriteLine("2. Lista alla kontakter");
                Console.WriteLine("3. Visa detaljer om en kontakt");
                Console.WriteLine("4. Ta bort en kontakt");
                Console.WriteLine("0. Avsluta");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ListContacts();
                        break;
                    case "3":
                        ViewContactDetails();
                        break;
                    case "4":
                        RemoveContact();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        private static void AddContact()
        {
            Console.WriteLine("Ange förnamn:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Ange efternamn:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Ange telefonnummer:");
            string phone = Console.ReadLine();

            Console.WriteLine("Ange e-postadress:");
            string email = Console.ReadLine();

            Console.WriteLine("Ange adress:");
            string address = Console.ReadLine();

            // Skapa en ny kontakt
            Contact contact = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Email = email,
                Address = address
            };

            _contactService.AddContact(contact);
            Console.WriteLine("Kontakten har lagts till.");
        }

        private static void ListContacts()
        {
            var contacts = _contactService.GetAllContacts();
            Console.WriteLine("Lista med kontakter:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}, E-post: {contact.Email}");
            }
        }

        private static void ViewContactDetails()
        {
            Console.WriteLine("Ange e-postadress för kontakten du vill visa:");
            string email = Console.ReadLine();
            var contact = _contactService.GetContactByEmail(email);
            if (contact != null)
            {
                Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Telefonnummer: {contact.Phone}");
                Console.WriteLine($"E-post: {contact.Email}");
                Console.WriteLine($"Adress: {contact.Address}");
            }
            else
            {
                Console.WriteLine("Kontakten hittades inte.");
            }
        }

        private static void RemoveContact()
        {
            Console.WriteLine("Ange e-postadress för kontakten du vill ta bort:");
            string email = Console.ReadLine();
            var contact = _contactService.GetContactByEmail(email);
            if (contact != null)
            {
                _contactService.RemoveContactByEmail(email);
                Console.WriteLine("Kontakten har tagits bort.");
            }
            else
            {
                Console.WriteLine("Kontakten hittades inte.");
            }
        }
    }



