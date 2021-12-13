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

        /// <summary> Добавить пустую строку для заполнения. </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEmptyLine_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddNewPersonCommand.Execute(null);
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeletePersonCommand.Execute(null);
        }

        private void ClonePerson_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ClonePersonCommand.Execute(null);
        }
    }
}
