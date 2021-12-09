using Lesson_3._1.Command;
using Lesson_3._1.Models;
using Lesson_3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lesson_3._1.ViewModels
{
    public class ProgramViewModel : BaseVM
    {
        private ObservableCollection<Person> _persons;
        private Person _selectPerson;

        public ObservableCollection<Person> PersonsList
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
            PersonsList = new ObservableCollection<Person>();
            AddNewPersonCommand = new RelayCommand(AddNewPerson_Command);
            DeletePersonCommand = new RelayCommand(DeletePerson_Command);
            ClonePersonCommand = new RelayCommand(ClonePerson_Command);
        }

        private void AddNewPerson_Command(object param)
        {
            List<string> personData = (List<string>)param;
            Person person = new Person(personData[0], personData[1], Int32.Parse(personData[2]), Double.Parse(personData[3]));
            PersonsList.Add(person);
            SelectPerson = person;
        }
        private void DeletePerson_Command(object param)
        {
            PersonsList.Remove(SelectPerson);
        }
        private void ClonePerson_Command(object param)
        {

        }
    }
}
