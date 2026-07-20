using module10contact.ViewModels;

namespace module10contact.Views
{
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage(ContactsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}