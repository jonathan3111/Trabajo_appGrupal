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
    public partial class PaginaRegistro : ContentPage
    {
        public PaginaRegistro()
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

        private async void OnRegistroButtonClicked(object sender, EventArgs e)
        {
            string nombre = NombreEntry.Text;
            string apellidoPaterno = ApellidoPaternoEntry.Text;
            string apellidoMaterno = ApellidoMaternoEntry.Text;
            int edad = Convert.ToInt32(EdadEntry.Text);
            string correo = CorreoEntry.Text;
            string contraseña = ContraseñaEntry.Text;

            // Validar que todos los campos se hayan completado
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidoPaterno) ||
                string.IsNullOrWhiteSpace(apellidoMaterno) || string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contraseña))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Crear un nuevo usuario
            var nuevoUsuario = new Usuario
            {
                Nombre = nombre,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                Edad = edad,
                Correo = correo,
                Contraseña = contraseña
            };

            // Guardar el usuario en la base de datos
            DatabaseService databaseService = new DatabaseService(App.DatabasePath);
            databaseService.GuardarUsuario(nuevoUsuario);

            await DisplayAlert("Éxito", "Registro exitoso", "OK");

            // Navegar a la página de inicio de sesión
            await Navigation.PushAsync(new PaginaInicioSesion());

            Navigation.RemovePage(this);
        }

        protected override bool OnBackButtonPressed()
        {
            // Evita que el botón de retroceso en la barra de navegación funcione
            return true;
        }
    }
}
    
