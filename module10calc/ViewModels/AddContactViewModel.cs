using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using module10contact.Models;
using module10contact.Views;
using Contact = module10contact.Models.Contact;

namespace module10contact.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly ContactsViewModel _contactsViewModel;

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

            Name = Email = Phone = Description = ErrorMessage = string.Empty;

            await Shell.Current.GoToAsync(nameof(ContactsPage));
        }
    }
}