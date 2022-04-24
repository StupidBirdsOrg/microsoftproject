using MyMicroservice;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRefitClient<IOrderInfoApi>()
    .ConfigureHttpClient(httpclient => httpclient.BaseAddress = new Uri(builder.Configuration.GetValue<string>("base_url")));

// Add services to the container.
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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
