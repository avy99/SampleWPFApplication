using System.Windows;

namespace SampleWPFApplication.Models
{
    public class Student : DependencyObject
    {
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(Student), new PropertyMetadata(""));

        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register("Email", typeof(string), typeof(Student), new PropertyMetadata(""));

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(Student), new PropertyMetadata(0));

        public string Name
        {
            get => (string) GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public string Email
        {
            get => (string) GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }


        public int Id
        {
            get => (int) GetValue(IdProperty);
            set => SetValue(IdProperty, value);
        }
    }
}