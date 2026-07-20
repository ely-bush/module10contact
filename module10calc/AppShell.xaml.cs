using module10contact.Views;

namespace module10contact
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
            Routing.RegisterRoute(nameof(ContactDetailPage), typeof(ContactDetailPage));
        }
    }
}
