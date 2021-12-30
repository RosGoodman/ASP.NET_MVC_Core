using Common.Entityes;

namespace Razor.Models
{
    public class ContactsViewModel
    {
        public List<Contact>? Contacts { get; set; }

        public ContactsViewModel()
        {
            Contacts = new List<Contact>();
            Contacts.Add(new Contact() 
            { 
                Name = "ООО «Развлекательный онлайн-сервис»",
                Address = "Пречистенская набережная, дом 13, " +
                "строение 1, этаж 3, офис 23 " +
                "Москва,Россия",
                LegalData= "ОГРН: 1207700255597 " +
                "Идентификационный номер налогоплательщика(ИНН): 9704024068"
            });
        }
    }
}
