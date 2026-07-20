using module10contact.ViewModels;

namespace module10contact.Views
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(ContactDetailViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}