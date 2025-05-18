
using AutoMapper;
using MediatR;
using System.Net;
using System.Text.Json;
using Vendedor.Aplicacion.Comun;
using Vendedor.Dominio.ObjetoValor;
using Vendedor.Dominio.Puerto.Integraciones;
using Vendedor.Dominio.Puertos.Integraciones;
using Vendedor.Dominio.Servicios.Vendedores;

namespace Vendedor.Aplicacion.Vendedor.Comandos
{
    public class VendedorCrearHandler : IRequestHandler<VendedorCrear, BaseOut>
    {
        private readonly IMapper _mapper;
        private readonly Registrar _registrarVendedor;
        private readonly IServicioAuditoriaApi _servicioAuditoriaApi;
        private readonly IServicioUsuariosApi _servicioUsuariosApi;

        public VendedorCrearHandler(IMapper mapper, Registrar registrarVendedor, IServicioAuditoriaApi servicioAuditoriaApi, IServicioUsuariosApi servicioUsuariosApi)
        {
            _mapper = mapper;
            _registrarVendedor = registrarVendedor;
            _servicioAuditoriaApi = servicioAuditoriaApi;
            _servicioUsuariosApi = servicioUsuariosApi;
        }

        public async Task<BaseOut> Handle(VendedorCrear request, CancellationToken cancellationToken)
        {
            BaseOut output = new();
            try
            {
                var vendedorNuevo = _mapper.Map<Dominio.Entidades.Vendedor>(request);
                await _registrarVendedor.Ejecutar(vendedorNuevo);
                var usuarioNuevo = _mapper.Map<UsuarioIn>(request);
                await _servicioUsuariosApi.CrearUsuario(usuarioNuevo);
                output.Mensaje = "Vendedor creado correctamente";
                output.Resultado = Resultado.Exitoso;
                output.Status = HttpStatusCode.Created;

                var inputAuditoria = _mapper.Map<Auditoria>(request);
                inputAuditoria.IdRegistro = vendedorNuevo.Id.ToString();
                inputAuditoria.Registro = JsonSerializer.Serialize(vendedorNuevo);
                _ = Task.Run(() => _servicioAuditoriaApi.RegistrarAuditoria(inputAuditoria), cancellationToken);
            }
            catch (Exception ex)
            {
                output.Resultado = Resultado.Error;
                output.Mensaje = string.Concat("Message: ", ex.Message, ex.InnerException is null ? "" : "-InnerException-" + ex.InnerException.Message);
                output.Status = HttpStatusCode.InternalServerError;
            }

            return output;

        }
    }
    
}
