using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using module10contact.Models;

namespace module6_contact.ViewModels
{
    // IQueryAttributable lets this ViewModel receive the selected Contact
    // object passed through Shell.GoToAsync's parameter dictionary.
    public partial class ContactDetailViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Contact contact = new();

        [ObservableProperty]
        private bool isEditing;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Contact", out var value) && value is Contact selected)
            {
                Contact = selected;
            }
        }

        [RelayCommand]
        private void Edit() => IsEditing = true;

        [RelayCommand]
        private void Save()
        {
            // The Entry fields on this page are two-way bound directly to
            // Contact.Name/Email/Phone/Description. Since Contact is the exact
            // same object reference stored in ContactsViewModel.Contacts, any
            // edits already live-update the list on ContactsPage automatically
            // (Contact implements ObservableObject, which raises PropertyChanged).
            IsEditing = false;
        }

        [RelayCommand]
        private async Task Back()
        {
            IsEditing = false;
            await Shell.Current.GoToAsync("..");
        }
    }
}