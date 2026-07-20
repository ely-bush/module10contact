using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using module10contact.Models;
using Conact = module10contact.Models.Contact;

namespace module10contact.ViewModels
{
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