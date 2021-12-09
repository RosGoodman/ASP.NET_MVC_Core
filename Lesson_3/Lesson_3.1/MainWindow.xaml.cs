using Lesson_3._1.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace Lesson_3._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProgramViewModel _viewModel;
        public MainWindow()
        {
            _viewModel = new ProgramViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            var personData = new List<string>();
            personData.Add(pName.Text);
            personData.Add(pSecName.Text);
            personData.Add(pAge.Text);
            personData.Add(pInsNumb.Text);
            _viewModel.AddNewPersonCommand.Execute(personData);
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeletePersonCommand.Execute(null);
        }

        private void ClonePerson_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeletePersonCommand.Execute(null);
        }
    }
}
