using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using EcoHuella.UserPages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EcoHuella
{
    public partial class App : Application
    {
        public static Context DbContext { get; set; }

        public App(String dbPath)
        {
            Debug.WriteLine($"Database located at: {dbPath}");
            DbContext = new Context(dbPath);

            InitializeComponent();

            MainPage = new NavigationPage(new UserData());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
