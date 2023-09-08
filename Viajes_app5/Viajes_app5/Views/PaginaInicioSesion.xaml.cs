using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Viajes_app5.Models;
using Viajes_app5.Services;

namespace Viajes_app5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicioSesion : ContentPage
    {
        public PaginaInicioSesion()
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

        private async void OnIniciarSesionButtonClicked(object sender, EventArgs e)
        {
            string correo = CorreoEntry.Text;
            string contraseña = ContraseñaEntry.Text;

            // Validar que se haya ingresado correo y contraseña
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contraseña))
            {
                await DisplayAlert("Error", "Por favor, ingrese correo y contraseña.", "OK");
                return;
            }

            // Verificar las credenciales en la base de datos
            DatabaseService databaseService = new DatabaseService(App.DatabasePath);
            Usuario usuario = databaseService.ObtenerUsuarioPorCorreo(correo);

            if (usuario != null && usuario.Contraseña == contraseña)
            {
                await DisplayAlert("Éxito", "Inicio de sesión exitoso", "OK");

                // Navegar a la página principal
                await Navigation.PushAsync(new PaginaPrincipal());
            }
            else
            {
                await DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }

        private async void OnRegistrarseButtonClicked(object sender, EventArgs e)
        {
            // Aquí puedes agregar cualquier lógica adicional que desees antes de navegar a la página de registro.

            // Navegar a la página de registro (PaginaRegistro)
            await Navigation.PushAsync(new PaginaRegistro());
        }
    }
}
    
