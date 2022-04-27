using MyMicroservice;
using MyMicroservice.Domain;
using MyMicroservice.Infrastructure;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRefitClient<IOrderInfoApi>()
    .ConfigureHttpClient(httpclient => httpclient.BaseAddress = new Uri(builder.Configuration.GetValue<string>("base_url")))
    .AddHttpMessageHandler<AuthHeaderHandler>();
builder.WebHost.ConfigureAppConfiguration(option=>
{
    Console.WriteLine("WEB_Configure");
});
builder.Services.AddScoped<IOperation,Operation>();

builder.Services.AddScoped<IOperation>(ServiceProvider=>
{
    return new Operation();
});
builder.Services.AddSingleton(typeof(IGenericService<>),typeof(GenericService<>));

builder.Services.AddTransient<AuthHeaderHandler>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // using System.Reflection;
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
