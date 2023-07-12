using Diary.Commands;
using Diary_WPF.Commands;
using Diary_WPF.Models;
using Diary_WPF.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Diary_WPF.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            AddStudentCommand = new RelayCommand(AddEditStudent);
            EditStudentCommand = new RelayCommand(AddEditStudent, CanEditDeleteStudent);
            DeleteStudentCommand = new AsyncRelayCommand(DeleteStudent, CanEditDeleteStudent);
            RefreshStudentCommand = new RelayCommand(RefreshStudent);

            RefreshDiary();

            InitGroups();

        }

        public ICommand AddStudentCommand { get; set; }
        public ICommand EditStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand RefreshStudentCommand { get; set; }


        private int _selectedGroupId;
        public int SelectedGroupId
        {
            get { return _selectedGroupId; ; }
            set
            {
                _selectedGroupId = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Group> _group;

        public ObservableCollection<Group> Groups
        {
            get { return _group; }
            set
            {
                _group = value;
                OnPropertyChanged();
            }
        }

        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private bool CanEditDeleteStudent(object obj)
        {
            return SelectedStudent != null;
        }

        private async Task DeleteStudent(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync(
                "Usuwanie ucznia",
                 $"czy na pewno chcesz usunąć ucznia{SelectedStudent.FirstName}," +
                 $"{SelectedStudent.LastName}?",
                 MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
            {
                return;
            }

            //usuwanie uczna z bazy

            RefreshDiary();
        }

        private void AddEditStudent(object obj)
        {
            var addEditStudentWindow = new AddEditStudentView();
            addEditStudentWindow.Closed += AddEditStudentWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }

        private void AddEditStudentWindow_Closed(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private void RefreshStudent(object obj)
        {
            RefreshDiary();
        }
        private void RefreshDiary()
        {
            Students = new ObservableCollection<Student>
            {
                new Student
                {
                    FirstName = "Kazimierz",
                    LastName = "Szpin",
                    Group = new Group
                    {Id=1 }
                },
                 new Student
                {
                    FirstName = "Marek",
                    LastName = "Nowak",
                    Group = new Group
                    {Id=2 }
                },
                 new Student
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Group = new Group
                    {Id=1 }
                },
            };
        }
        private void InitGroups()
        {
            Groups = new ObservableCollection<Group>()
           {
                new Group {Id=0, Name="Wszyscy"},
                new Group {Id=1, Name="1A"},
                new Group {Id=2, Name="2A"}
           };
            _selectedGroupId = 0;

        }


    }


}
