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
        public Context Context { get; set; }

        public App(String dbPath)
        {
            Debug.WriteLine($"Database located at: {dbPath}");
            Context = new Context(dbPath);

            InitializeComponent();

            MainPage = new UserData();
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
