using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Viajes_app5.Models;

using Xamarin.Forms;

namespace Viajes_app5.Services
{
    public class DatabaseService 
    {
        readonly SQLiteConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Usuario>();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _database.Table<Usuario>().ToList();
        }

        public void GuardarUsuario(Usuario usuario)
        {
            _database.Insert(usuario);
        }

        public Usuario ObtenerUsuarioPorCorreo(string correo)
        {
            return _database.Table<Usuario>().FirstOrDefault(u => u.Correo == correo);
        }
    }
}