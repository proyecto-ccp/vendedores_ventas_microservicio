using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Productos.Infraestructura.Adaptadores.Repositorios;
using System.Reflection;
using Vendedor.Dominio.Puerto.Integraciones;
using Vendedor.Dominio.Puerto.Repositorios;
using Vendedor.Dominio.Puertos.Integraciones;
using Vendedor.Dominio.Servicios.Vendedores;
using Vendedor.Infraestructura.Adaptadores.Integraciones;
using Vendedor.Infraestructura.Adaptadores.RepositorioGenerico;
using Vendedor.Infraestructura.Adaptadores.Repositorios;
using Vendedor.Infraestructura.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V.1.0.1",
        Title = "Servicio Vendedores",
        Description = "Administración de vendedores"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            Array.Empty<string>()
            }
        });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("Vendedor.Aplicacion")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Capa Infraestructura
builder.Services.AddDbContext<VendedoresDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("VendedoresDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient<IVendedorRepositorio, VendedorRepositorio>();
builder.Services.AddTransient<IDocumentoRepositorio, DocumentosRepositorio>();
builder.Services.AddHttpClient<IServicioUsuariosApi, ServicioUsuariosApi>();
builder.Services.AddHttpClient<IServicioAuditoriaApi, ServicioAuditoriaApi>();
builder.Services.AddTransient<IReporteVentasRepositorio, ReporteVentasRepositorio>();
//Capa Dominio - Servicios
builder.Services.AddTransient<Registrar>();
builder.Services.AddTransient<Consultar>();
builder.Services.AddTransient<ReporteVentas>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();

