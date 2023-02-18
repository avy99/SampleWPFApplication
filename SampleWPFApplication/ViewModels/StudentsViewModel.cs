using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SampleWPFApplication.Models;

namespace SampleWPFApplication.ViewModels
{
    public class StudentsViewModel : DependencyObject
    {
        // Using a DependencyProperty as the backing store for UserMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddUserMessageProperty =
            DependencyProperty.Register("AddUserMessage", typeof(string), typeof(StudentsViewModel),
                new PropertyMetadata(""));

        public static readonly DependencyProperty UpdateUserMessageProperty =
            DependencyProperty.Register("UpdateUserMessage", typeof(string), typeof(StudentsViewModel),
                new PropertyMetadata(""));

        // Using a DependencyProperty as the backing store for IsTextBoxToBeCleared.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTextBoxToBeClearedProperty =
            DependencyProperty.Register("IsTextBoxToBeCleared", typeof(bool), typeof(StudentsViewModel),
                new PropertyMetadata(false));

        private int studentId;

        public StudentsViewModel()
        {
            Students = new ObservableCollection<Student>();
            LoadStudets();
            studentId = Students.Count;
            AddCommand = new RelayCommand(AddStudents, CanAddStudent);
            UpdateCommand = new RelayCommand(UpdateStudent, CanUpdateStudent);
            DeleteCommand = new RelayCommand(DeleteStudent, CanDeleteStudent);
        }


        public bool IsTextBoxToBeCleared
        {
            get => (bool) GetValue(IsTextBoxToBeClearedProperty);
            set => SetValue(IsTextBoxToBeClearedProperty, value);
        }


        public string AddUserMessage
        {
            get => (string) GetValue(AddUserMessageProperty);
            set => SetValue(AddUserMessageProperty, value);
        }

        public string UpdateUserMessage
        {
            get => (string) GetValue(UpdateUserMessageProperty);
            set => SetValue(UpdateUserMessageProperty, value);
        }


        public ObservableCollection<Student> Students { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadStudets()
        {
            Students.Add(new Student {Id = 1, Name = "Ak", Email = "a@12"});
            Students.Add(new Student {Id = 2, Name = "Bk", Email = "b@12"});
            Students.Add(new Student {Id = 3, Name = "Ck", Email = "c@12"});
        }


        private void AddStudents(object obj)
        {
            var stu = obj as Student;
            studentId++;
            stu.Id = studentId;
            Students.Add(stu);
            AddUserMessage = $"Student with Id:{stu.Id} is Added Successfully";
            IsTextBoxToBeCleared = true;
            IsTextBoxToBeCleared = false;
        }

        private bool CanAddStudent(object obj)
        {
            if (obj == null) return false;
            var stu = obj as Student;
            if (string.IsNullOrWhiteSpace(stu.Name) || string.IsNullOrWhiteSpace(stu.Email)) return false;
            if (Students.Any(x => x.Email == stu.Email || x.Name == stu.Name)) return false;
            return true;
        }

        private bool CanUpdateStudent(object obj)
        {
            if (obj == null) return false;

            if (obj != null && (obj as Student).Id != 0)
            {
                var stu = obj as Student;
                var orgStu = Students.First(x => x.Id == stu.Id);
                if (!stu.Name.Equals(orgStu.Name) || !stu.Email.Equals(orgStu.Email)) return true;
            }

            return false;
        }

        private void UpdateStudent(object obj)
        {
            var stu = obj as Student;
            var orgStu = Students.First(x => x.Id == stu.Id);
            Students[Students.IndexOf(orgStu)] = stu;
            UpdateUserMessage = $"Student with Id:{stu.Id} is Updated Successfully";
        }

        private bool CanDeleteStudent(object obj)
        {
            if (obj != null && obj is Student) return true;
            return false;
        }

        private void DeleteStudent(object obj)
        {
            var stu = obj as Student;
            Students.Remove(stu);
            UpdateUserMessage = $"Student with Id:{stu.Id} is Deleted Successfully";
        }

        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}