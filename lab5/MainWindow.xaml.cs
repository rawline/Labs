using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ContactsApp
{
    public class Contact : INotifyPropertyChanged
    {
        private string _name;
        private string _email;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Contacts = new ObservableCollection<Contact>
            {
                new Contact { Name = "ВВП", Email = "SECRET INFORMATION" },
                new Contact { Name = "Шрек", Email = "shrek@swamp.com" },
                new Contact { Name = "Осел", Email = "donkey@swamp.com" }
            };
            DataContext = this;
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return; // Завершаем метод, если поля пустые
            }
            // Получаем данные из текстовых полей
            string newName = NameTextBox.Text;
            string newEmail = EmailTextBox.Text;

            // Создаем новый объект Contact
            Contact newContact = new Contact { Name = newName, Email = newEmail };

            // Добавляем его в коллекцию Contacts
            Contacts.Add(newContact);

            // Выбираем новый контакт в списке
            ContactsList.SelectedItem = newContact;

            // Очищаем текстовые поля
            NameTextBox.Clear();
            EmailTextBox.Clear();
        }


        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный контакт из ListBox
            Contact selectedContact = ContactsList.SelectedItem as Contact;

            // Проверяем, что контакт не null (что-то выбрано в ListBox)
            if (selectedContact != null)
            {
                if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.");
                    return; // Завершаем метод, если поля пустые
                }
                // Обновляем данные контакта из текстовых полей
                selectedContact.Name = NameTextBox.Text;
                selectedContact.Email = EmailTextBox.Text;

                // Снимаем выделение с ListBox
                ContactsList.SelectedItem = null;

                // Очищаем текстовые поля
                NameTextBox.Clear();
                EmailTextBox.Clear();
            }
        }
    }
}
