using Diary_WPF.Models;
using Diary_WPF.ViewModels;
using MahApps.Metro.Controls;

namespace Diary_WPF.Views
{
    /// <summary>
    /// Interaction logic for AddEditStudentView.xaml
    /// </summary>
    public partial class AddEditStudentView : MetroWindow
    {
        public AddEditStudentView(Student student = null)
        {
            InitializeComponent();

            DataContext = new AddEditStudentsViewModels(student);
        }

    }

}
