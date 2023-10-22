using MemoryCache.Labs.Infrastructure;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient(AppConstants.HTTP_CLIENT_NAME, httpClient =>
{
    httpClient.BaseAddress = new Uri("https://ludopedia.com.br/api/v1/");

    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Authorization, "Bearer " + builder.Configuration.GetValue<string>("LUDOPEDIA_SECRET"));
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:109.0) Gecko/20100101 Firefox/118.0");
});

builder.Services.AddInfrastructureServices();

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
