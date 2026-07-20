using CommunityToolkit.Mvvm.ComponentModel;

namespace module10contact.Models
{
    public partial class Contact : ObservableObject
    {
        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phone = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        public string Initial => string.IsNullOrWhiteSpace(Name) ? "?" : Name.Trim()[0].ToString().ToUpper();
    }
}