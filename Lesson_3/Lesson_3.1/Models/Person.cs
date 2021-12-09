
namespace Lesson_3._1.Models
{
    public class Person
    {
        private string _name;
        private string _secondName;
        private int _age;
        private double _insuranceNumber;


        public string Name { get; private set; }
        public string SecondName { get; private set; }
        public int Age { get; private set; }

        public Person(string name, string secName, int age, double insuranceNumber)
        {
            _name = name;
            _secondName = secName;
            _age = age;
            _insuranceNumber = insuranceNumber;
        }

        /// <summary> Получить номер страховки. </summary>
        /// <returns> Номер сраховки. </returns>
        public double GetInsuranceNumber() => _insuranceNumber;
    }
}
