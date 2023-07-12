using System.Net.Http.Headers;
using Searchia.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISearchiaQueryClient, SearchiaQueryClient>();
builder.Services.AddSingleton<ISearchiaCommandClient, SearchiaCommandClient>();
builder.Services.AddSingleton<ISearchiaBannedExpressionClient, SearchiaBannedExpressionClient>();
builder.Services.AddHttpClient(SearchiaClient.ClientName,
    option =>
    {
        option.BaseAddress = new Uri("https://searchia.ir/");
        option.DefaultRequestHeaders
            .Accept
            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        option.DefaultRequestHeaders.Add("apikey", "71E04AC162F9493DB685363476A52E58");
    });


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
