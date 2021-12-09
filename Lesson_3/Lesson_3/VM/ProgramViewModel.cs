
using Lesson_3.Command;
using Lesson_3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lesson_3
{
    public class ProgramViewModel : BaseViewModel
    {
        private ObservableCollection<Person> _persons;
        private Person _selectPerson;

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            set
            {
                _persons = value;
                OnPropertyChanged("Persons");
            }
        }

        public Person SelectPerson
        {
            get => _selectPerson;
            set
            {
                _selectPerson = value;
                OnPropertyChanged("SelectPerson");
            }
        }

        public RelayCommand AddNewPersonCommand { get; private set; }
        public RelayCommand DeletePersonCommand { get; private set; }
        public RelayCommand ClonePersonCommand { get; private set; }

        public ProgramViewModel()
        {
            Persons = new ObservableCollection<Person>();
            AddNewPersonCommand = new RelayCommand(AddNewPerson_Command);
            DeletePersonCommand = new RelayCommand(DeletePerson_Command);
            ClonePersonCommand = new RelayCommand(ClonePerson_Command);
        }

        private void AddNewPerson_Command(object param)
        {
            List<string> personData = (List<string>)param;
            Person person = new Person(personData[0], personData[1], Int32.Parse(personData[2]), Double.Parse(personData[3]));
            Persons.Add(person);
            SelectPerson = person;
        }
        private void DeletePerson_Command(object param)
        {
            Persons.Remove(SelectPerson);
        }
        private void ClonePerson_Command(object param)
        {

        }
    }
}
