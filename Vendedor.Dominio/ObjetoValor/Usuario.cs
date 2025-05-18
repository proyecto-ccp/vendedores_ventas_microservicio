
namespace Vendedor.Dominio.ObjetoValor
{
    public class UsuarioIn
    {
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public Guid IdRol { get; set; }

    }
    public class UsuarioOut
    {
        public Guid IdUsuario { get; set; }
        public Guid IdRol { get; set; }
        public int Resultado { get; set; }
        public string Mensaje { get; set; }
        public int Status { get; set; }
    }
}
