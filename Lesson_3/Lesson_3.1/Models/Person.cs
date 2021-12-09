
using System;

namespace Lesson_3._1.Models
{
    [Serializable]
    public class Person
    {
        private string _name;
        private string _secondName;
        private int _age;
        private Address _address;

        /// <summary> Имя. </summary>
        public string Name { get => _name; set => _name = value; }

        /// <summary> Фамилия. </summary>
        public string SecondName { get => _secondName; set => _secondName = value; }

        /// <summary> Возраст. </summary>
        public int Age { get => _age; set => _age = value; }

        /// <summary> Адрес. </summary>
        public Address Address { get => _address; set => _address = value; }

        public Person() { _address = new Address(); }

        public Person(string name, string secName, int age, string street, int buldNumb)
        {
            _address = new Address();

            _name = name;
            _secondName = secName;
            _age = age;
            _address.Street = street;
            _address.BuildNumb = buldNumb;
        }
    }

    [Serializable]
    public class Address
    {
        private string _street;
        private int _buildNumb;

        /// <summary> Название улицы. </summary>
        public string Street { get => _street; set => _street = value; }

        /// <summary> Номер дома. </summary>
        public int BuildNumb { get => _buildNumb; set => _buildNumb = value; }
    }
}
