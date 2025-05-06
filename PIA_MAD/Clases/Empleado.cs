using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Clases
{
    public class Empleado
    {
        private int _id;
        private string _nombre;
        private string _apellidoPaterno;
        private string _apellidoMaterno;
        private string _correo;
        private string _rol;


        private static Empleado _instancia;

        private Empleado(int id, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string rol)
        {
            _id = id;
            _nombre = nombre;
            _apellidoPaterno = apellidoPaterno;
            _apellidoMaterno = apellidoMaterno;
            _correo = correo;
            _rol = rol;
        }

        public static void IniciarSesion(int id, string nombre, string apellidoPaterno, string apellidoMaterno, string correo, string rol)
        {
            _instancia = new Empleado(id, nombre, apellidoPaterno, apellidoMaterno, correo, rol);
        }

        public static Empleado ObtenerInstancia()
        {
            return _instancia;
        }

        public int GetId() => _id;
        public string GetNombre() => _nombre;
        public string GetApellidoPaterno() => _apellidoPaterno;
        public string GetApellidoMaterno() => _apellidoMaterno;
        public string GetCorreo() => _correo;
        public string GetRol() => _rol;
        public string GetNombreCompleto() => $"{_nombre} {_apellidoPaterno} {_apellidoMaterno}";

        public static void CerrarSesion()
        {
            _instancia = null;
        }
    }
}
