using Microsoft.OpenApi.Models;
using PruebaTecnicaCarsales.Services;

var builder = WebApplication.CreateBuilder(args);
var rmApiBase = builder.Configuration["RickAndMortyApi:BaseUrl"];
var apiKey = builder.Configuration["ApiKey"];
                                                                                    
builder.Services
    .AddHttpClient<RickAndMortyService>(client =>
    {
        client.BaseAddress = new Uri(rmApiBase);
    });
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PruebaTecnicaCarsales API",
        Version = "v1",
    });

    c.AddSecurityDefinition("ApiKeyAuth", new OpenApiSecurityScheme
    {
        Description = "Enter your API Key in the header X-Api-Key",
        Name = "X-Api-Key",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKeyAuth"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKeyAuth"
                }
            },
            new string[] {}
        }
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaTecnicaCarsales API V1");
    c.RoutePrefix = "swagger";
});

app.UseCors("AllowAngularDev");

app.Use(async (ctx, next) =>
{
    if (ctx.Request.Method == "OPTIONS")
    {
        await next();
        return;
    }

    if (ctx.Request.Path.StartsWithSegments("/swagger"))
    {
        await next();
        return;
    }

    if (!ctx.Request.Headers.TryGetValue("X-Api-Key", out var incoming)
        || incoming != apiKey)
    {
        ctx.Response.StatusCode = 401;
        await ctx.Response.WriteAsync("Unauthorized");
        return;
    }

    await next();
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
