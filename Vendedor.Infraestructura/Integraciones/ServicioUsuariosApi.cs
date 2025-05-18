
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Dominio.Puerto.Integraciones;

namespace Vendedor.Infraestructura.Adaptadores.Integraciones
{
    [ExcludeFromCodeCoverage]
    public class ServicioUsuariosApi : IServicioUsuariosApi
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public ServicioUsuariosApi(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<UsuarioOut> CrearUsuario(UsuarioIn usuario)
        {
            var uri = _configuration["UriAutorizador"];
            var respuesta = await _httpClient.PostAsJsonAsync(uri, usuario);
            respuesta.EnsureSuccessStatusCode();
            var objRespuesta = await respuesta.Content.ReadFromJsonAsync<UsuarioOut>();
            return objRespuesta;
        }
    }
}
