﻿using Diary.Commands;
using Diary_WPF.Commands;
using Diary_WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Diary_WPF.ViewModels
{
    internal class AddEditStudentsViewModels : ViewModelBase
    {

        public AddEditStudentsViewModels(Student student = null)
        {
            CloseCommand = new RelayCommand (Close);
            ConfirmCommand = new RelayCommand (Confirm);

            if (student == null)
            {
                Student = new Student();
            }
            else
            {
                Student = student;
                IsUpdate = true;
            }

            InitGroups();
           
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private Student _student;

        public Student Student
        {
            get { return _student; }
            set
            {
                _student = value;
                OnPropertyChanged();
            }
        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }

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

        public Action<object, EventArgs> Closed { get; internal set; }

        private void InitGroups()
        {
            Groups = new ObservableCollection<Group>()
           {
                new Group {Id=0, Name="--brak--"},
                new Group {Id=1, Name="1A"},
                new Group {Id=2, Name="2A"}
           };
            
            Student.Group.Id = 0;

        }

        private void Confirm(object obj)
        {
            if (!IsUpdate)

                AddStudent();
            else
                UpdadeStudent();

            CloseWindow(obj as Window);
        }

        private void UpdadeStudent()
        {
            //baza danych
        }

        private void AddStudent()
        {
            //baza danych
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}
