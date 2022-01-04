
using System.Collections;

namespace Common.Entityes;

public class Contact
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string LegalData { get; set; }
}

public class ContactsList
{
    Contact[] contacts = null;
    public ContactsList()
    {
        var contact1 = new Contact()
        {
            Name = "ООО «Развлекательный онлайн-сервис»",
            Address = "Пречистенская набережная, дом 13, " +
                "строение 1, этаж 3, офис 23 " +
                "Москва,Россия",
            LegalData = "ОГРН: 1207700255597 " +
                "Идентификационный номер налогоплательщика(ИНН): 9704024068"
        };

        contacts = new Contact[1];
        contacts[0] = contact1;
    }

    public IEnumerator GetEnumerator()
    {
        return new ContactsEnumertor(contacts);
    }
}
