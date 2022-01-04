using Common.Entityes;

namespace Razor.Models
{
    public class ContactsViewModel
    {
        public ContactsList ContactsList { get; set; }

        public ContactsViewModel()
        {
            ContactsList = new ContactsList();
            foreach(var c in ContactsList)
            {
                Contact contact = (Contact)c;
            }
        }
    }
}
