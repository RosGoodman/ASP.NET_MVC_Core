
namespace Common.Entityes;

public class Contact
{
    public string Name { get; set; }
    public List<string> Address { get; set; }
    public List<string> LegalData { get; set; }
}

public class ContactData
{
    //для выполнения задания, в качестве примера, была взята страница
    //https://help.netflix.com/ru/legal/corpinfo

    public List<Contact> Contacts { get; set;}

    public ContactData()
    {
        Contacts = new List<Contact>
        {
            new Contact()
            {
                Name = "ООО «Развлекательный онлайн-сервис»",
                Address = new List<string>() { "Пречистенская набережная, дом 13,", "строение 1, этаж 3, офис 23", "Москва,Россия" },
                LegalData = new List<string>() {  "ОГРН: 1207700255597", "Идентификационный номер налогоплательщика(ИНН): 9704024068" }
            },
            new Contact()
            {
                Name = "Netflix International B.V.",
                Address = new List<string>() { "Karperstraat 8-10", "1075 KZ Amsterdam, the Netherlands" },
                LegalData = new List<string>() { "KvK: 62266519", "НДС: NL853746333B01", "Уставный капитал: 12 500 евро" }
            },
            new Contact()
            {
                Name = "Netflix, Inc.",
                Address = new List<string>() { "100 Winchester Circle", "Los Gatos, CA 95032, USA" },
                LegalData = new List<string>() { "" }
            },
            new Contact()
            {
                Name = "Netflix Entretenimento Brasil, Ltda.",
                Address = new List<string>() { "Alameda Xingu, 350 - 14º andar - Alphaville Industrial", "Barueri, CEP 06455-911 - SP - Brazil" },
                LegalData = new List<string>() { "CNPJ: 13.590.585/0002-70" }
            },
            new Contact()
            {
                Name = "Netflix Entertainment Services India LLP",
                Address = new List<string>() { "Level 11, Godrej BKC, Plot C-68", "G Block, BKC- Bandra (East)", "Mumbai 400051, India" },
                LegalData = new List<string>() { "" }
            },
            new Contact()
            {
                Name = "Netflix G.K.",
                Address = new List<string>() { "Tokyo Midtown East 3F", "9-7-2 Akasaka", "Minato-ku", "Tokyo 107-0052 Japan" },
                LegalData = new List<string>() { "ОГРН: 1207700255597", "Идентификационный номер налогоплательщика(ИНН): 9704024068" }
            },
            new Contact()
            {
                Name = "Netflix Services Korea Ltd.",
                Address = new List<string>() { "20F, Tower A, Centropolis Building", "26, Ujeongguk-ro, Jongno-gu, Seoul, 03161, Republic of Korea" },
                LegalData = new List<string>() { "" }
            },
            new Contact()
            {
                Name = "Netflix Services UK Limited",
                Address = new List<string>() { "100 New Bridge Street, London, EC4V 6JA" },
                LegalData = new List<string>() { "Номер компании (регистрационный): 9091899", "Регистрационный номер плательщика налога на прибыль: 623 25810 01805 A" }
            },
            new Contact()
            {
                Name = "Netflix Pte. Ltd.",
                Address = new List<string>() { "9 Straits View, Marina One West Tower #14-07/12, Singapore 018937" },
                LegalData = new List<string>() { "Регистрационный идентификационный номер: 201531197W" }
            },
            new Contact()
            {
                Name = "Netflix Services France S.A.S.",
                Address = new List<string>() { "11 Place Édouard VII, 75009 Paris, France" },
                LegalData = new List<string>() { "Учетный номер компании: 843 655 549 RCS Paris" }
            },
            new Contact()
            {
                Name = "Netflix Servicios de Transmisión España, S.L.",
                Address = new List<string>() { "Paseo de la Castellana 89, 28046 Madrid, Spain" },
                LegalData = new List<string>() { "Номер плательщика НДС / NIF: B88182514" }
            },
            new Contact()
            {
                Name = "Netflix México S. de R.L. de C.V.",
                Address = new List<string>() { "Prado Sur 150, Floor 4. Lomas de Chapultepec, ZC: 11000. CDMX" },
                LegalData = new List<string>() { "Регистрационный номер: 112483", "RFC (налоговый идентификатор): NME110513P13" }
            },
            new Contact()
            {
                Name = "Netflix Australia Pty Ltd",
                Address = new List<string>() { "Level 19, 181 William Street" },
                LegalData = new List<string>() { "Melbourne VIC 3000, Australia" }
            },
            new Contact()
            {
                Name = "Netflix Services Germany GmbH",
                Address = new List<string>() { "Friedrichstraße 88", "10117, Berlin, Germany" },
                LegalData = new List<string>() { "" }
            },
            new Contact()
            {
                Name = "Netflix Services Italy S.R.L.",
                Address = new List<string>() { "Via Boncompagni no. 8-10, Villino Rattazzi ", "" },
                LegalData = new List<string>() { "" }
            },
            new Contact()
            {
                Name = "Netflix Services Canada ULC",
                Address = new List<string>() { "1200 Waterfront Centre, 200 Burrard St", "Vancouver BC V7X 1T2, Canada" },
                LegalData = new List<string>() { "" }
            }
        };
    }
}
