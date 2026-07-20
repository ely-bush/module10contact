using module10contact.ViewModels;

namespace module10contact.Views
{
    public partial class AddContactPage : ContentPage
    {
        public AddContactPage(AddContactViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}