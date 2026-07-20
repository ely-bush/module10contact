using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using module10contact.Models;
using module10contact.Views;

namespace module6_contact.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly ContactsViewModel _contactsViewModel;

        // Injected because it's registered as a Singleton — this is the SAME
        // instance ContactsPage binds to, so adding here shows up there instantly.
        public AddContactViewModel(ContactsViewModel contactsViewModel)
        {
            _contactsViewModel = contactsViewModel;
        }

        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phone = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        [RelayCommand]
        private async Task Save()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            {
                ErrorMessage = "Name and email are required.";
                return;
            }

            var contact = new Contact
            {
                Name = Name.Trim(),
                Email = Email.Trim(),
                Phone = Phone.Trim(),
                Description = Description.Trim()
            };

            _contactsViewModel.Contacts.Add(contact);

            // Reset the form for the next contact
            Name = Email = Phone = Description = ErrorMessage = string.Empty;

            await Shell.Current.GoToAsync(nameof(ContactsPage));
        }
    }
}