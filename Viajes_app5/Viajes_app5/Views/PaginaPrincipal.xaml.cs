using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Viajes_app5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            // Elimina la página de inicio de sesión de la pila de navegación
            var existingPages = Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page is PaginaInicioSesion)
                {
                    Navigation.RemovePage(page);
                }
            }
        }

        private async void OnCerrarSesionButtonClicked(object sender, EventArgs e)
        {
            // Aquí debes implementar la lógica para cerrar la sesión.
            // Esto podría incluir la eliminación de tokens de sesión, la limpieza de datos de autenticación, etc.

            // Elimina la página actual de la pila de navegación
            Navigation.RemovePage(this);

            // Navegar a la página de inicio de sesión
            await Navigation.PushAsync(new PaginaInicioSesion());
        }

        protected override bool OnBackButtonPressed()
        {
            // Evita que el botón de retroceso en la barra de navegación funcione
            return true;
        }
    }
}