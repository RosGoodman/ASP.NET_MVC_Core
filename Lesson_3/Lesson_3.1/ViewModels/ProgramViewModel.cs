using Lesson_3._1.Command;
using Lesson_3._1.Models;
using Lesson_3.ViewModel;
using System.Collections.ObjectModel;

namespace Lesson_3._1.ViewModels
{
    public class ProgramViewModel : BaseVM
    {
        private ObservableCollection<Person> _persons;
        private Person _selectPerson;

        /// <summary> Список людей. </summary>
        public ObservableCollection<Person> PersonsList
        {
            get => _persons;
            set
            {
                _persons = value;
                OnPropertyChanged("PersonsList");
            }
        }

        /// <summary> Выбранный человк в списке. </summary>
        public Person SelectPerson
        {
            get => _selectPerson;
            set
            {
                _selectPerson = value;
                OnPropertyChanged("SelectPerson");
            }
        }

        /// <summary> Команда. Добавить в список пустой экзмепляр для заполнения. </summary>
        public RelayCommand AddNewPersonCommand { get; private set; }
        /// <summary> Команда. Удалить человека из списка. </summary>
        public RelayCommand DeletePersonCommand { get; private set; }
        /// <summary> Команда. Клонировать данные. </summary>
        public RelayCommand ClonePersonCommand { get; private set; }

        public ProgramViewModel()
        {
            PersonsList = new ObservableCollection<Person>();

            AddNewPersonCommand = new RelayCommand(AddNewPerson_Command);
            DeletePersonCommand = new RelayCommand(DeletePerson_Command);
            ClonePersonCommand = new RelayCommand(ClonePerson_Command);
        }

        /// <summary> Добавить человека в список. </summary>
        /// <param name="param"></param>
        private void AddNewPerson_Command(object param)
        {
            Person person = new Person();
            PersonsList.Add(person);
            SelectPerson = person;
        }

        /// <summary> Удалть человека из списка. </summary>
        /// <param name="param"></param>
        private void DeletePerson_Command(object param)
        {
            PersonsList.Remove(SelectPerson);

            if (PersonsList.Count == 0) return;
            SelectPerson = PersonsList[0];
        }

        /// <summary> Клонировать данные человека. </summary>
        /// <param name="param"></param>
        private void ClonePerson_Command(object param)
        {
            Person clonePerson = new Person
            {
                Name = SelectPerson.Name,
                SecondName = SelectPerson.SecondName,
                Age = SelectPerson.Age,
                //тут, благодаря паттерну прототип копируется вложенный класс
                Address = SelectPerson.Address.DeepCopy()
            };

            PersonsList.Add(clonePerson);
            SelectPerson = clonePerson;
        }
    }
}
