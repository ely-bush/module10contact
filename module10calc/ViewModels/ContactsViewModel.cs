using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using module10contact.Models;
using module10contact.Views;

namespace module10contact.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        public ObservableCollection<Contact> Contacts { get; } = new();

        [ObservableProperty]
        private Contact? selectedContact;

        partial void OnSelectedContactChanged(Contact? value)
        {
            if (value is null) return;
            _ = NavigateToDetailAsync(value);
            SelectedContact = null;
        }

        private async Task NavigateToDetailAsync(Contact contact)
        {
            var parameters = new Dictionary<string, object> { { "Contact", contact } };
            await Shell.Current.GoToAsync(nameof(ContactDetailPage), parameters);
        }

        [RelayCommand]
        private async Task GoToAddContact()
        {
            await.Shell.Current.GoToAsync("..");
        }
    }
}
