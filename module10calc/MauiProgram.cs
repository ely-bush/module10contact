using Microsoft.Extensions.Logging;
using module10contact.ViewModels;
using module10contact.Views;

namespace module10contact
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // ViewModels
            builder.Services.AddSingleton<ContactsViewModel>();   // shared across the whole app
            builder.Services.AddTransient<AddContactViewModel>();
            builder.Services.AddTransient<ContactDetailViewModel>();

            // Views
            builder.Services.AddTransient<AddContactPage>();
            builder.Services.AddTransient<ContactsPage>();
            builder.Services.AddTransient<ContactDetailPage>();

            return builder.Build();
        }
    }
}