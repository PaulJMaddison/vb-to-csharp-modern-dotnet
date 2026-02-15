using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

const string issuer = "WebApiWithAuth";
const string audience = "WebApiWithAuthClients";
const string devSigningKey = "THIS_IS_DEV_ONLY_CHANGE_ME_1234567890"; // Local learning only.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(devSigningKey))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API With Auth", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Paste your JWT token here: Bearer {token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// For browser apps, cookie auth is common: browser sends cookie automatically.
// For APIs/mobile/SPA clients, JWT bearer tokens are common: client sends token explicitly.
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/public/ping", () => Results.Ok(new { Message = "Public endpoint. No token required." }));

app.MapGet("/secure/profile", (ClaimsPrincipal user) =>
    Results.Ok(new
    {
        Message = "Protected endpoint. Token was validated.",
        User = user.Identity?.Name ?? "anonymous"
    }))
    .RequireAuthorization();

// WARNING: DEV/LEARNING ONLY. Do not issue tokens like this in production.
app.MapPost("/auth/dev-token", (DevTokenRequest request) =>
{
    var claims = new[]
    {
        new Claim(ClaimTypes.NameIdentifier, request.UserName),
        new Claim(ClaimTypes.Name, request.UserName),
        new Claim(ClaimTypes.Role, "Learner")
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(devSigningKey));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var expires = DateTime.UtcNow.AddMinutes(30);

    var token = new JwtSecurityToken(
        issuer: issuer,
        audience: audience,
        claims: claims,
        expires: expires,
        signingCredentials: creds);

    return Results.Ok(new
    {
        access_token = new JwtSecurityTokenHandler().WriteToken(token),
        token_type = "Bearer",
        expires_utc = expires
    });
});

app.Run();

public record DevTokenRequest(string UserName);
