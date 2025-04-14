
using AutoMapper;
using MediatR;
using System.Net;
using Vendedor.Aplicacion.Comun;
using Vendedor.Dominio.Servicios.Vendedores;

namespace Vendedor.Aplicacion.Vendedor.Comandos
{
    public class VendedorCrearHandler : IRequestHandler<VendedorCrear, BaseOut>
    {
        private readonly IMapper _mapper;
        private readonly Registrar _registrarVendedor;

        public VendedorCrearHandler(IMapper mapper, Registrar registrarVendedor)
        {
            _mapper = mapper;
            _registrarVendedor = registrarVendedor;
        }

        public async Task<BaseOut> Handle(VendedorCrear request, CancellationToken cancellationToken)
        {
            BaseOut output = new();
            try
            {
                var vendedorNuevo = _mapper.Map<Dominio.Entidades.Vendedor>(request);
                await _registrarVendedor.Ejecutar(vendedorNuevo);
                output.Mensaje = "Vendedor creado correctamente";
                output.Resultado = Resultado.Exitoso;
                output.Status = HttpStatusCode.Created;
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
