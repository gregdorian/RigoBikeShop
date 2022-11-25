var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//private static readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["sqlConexionApp"].ConnectionString;
private static readonly string cadenaConexion = "Data Source=ACER-5151\\SQLEXPRESS01;Initial Catalog=cyclingbikeshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
private static SqlConnection conexion = new SqlConnection(cadenaConexion);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
