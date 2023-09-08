using System;
using Viajes_app5.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Viajes_app5
{
    public partial class App : Application
    {
        public static string DatabasePath { get; set; }
        public App()
        {
            InitializeComponent();

            DatabasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Viaje.db3");

            // Establece la página de inicio de sesión como página principal
            MainPage = new NavigationPage(new PaginaInicioSesion());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
