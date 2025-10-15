using AppBank_Back.Application;
using AppBank_Back.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// --- Dependency Injection Setup ---
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
// --- End of Setup ---

// --- INICIO DE LA CONFIGURACIÓN DE CORS ---
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Cuando crees tu frontend, pondrás su dirección aquí.
                          // Por ahora, usaremos la de Next.js por defecto.
                          policy.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});
// --- FIN DE LA CONFIGURACIÓN DE CORS ---


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usa la política de CORS que definimos arriba
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();