using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add UserService
builder.Services.AddScoped<UserService>();

// Add CORS - allow requests from Angular frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add JWT Bearer Authentication
// Note: For now, we're not validating the token signature, just extracting claims
// This is for learning purposes. In production, validate properly.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = false,  // Skip validation for learning
            ValidateIssuer = false,             // Skip validation for learning
            ValidateAudience = false,           // Skip validation for learning
            ValidateLifetime = false,           // Skip expiration validation for learning
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key-for-learning"))
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                context.NoResult();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                return context.Response.WriteAsJsonAsync(new { message = "Unauthorized" });
            }
        };
    });

// Add OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseCors("AllowAngular");
}

// Middleware order matters
app.UseAuthentication();  // Must be before UseAuthorization
app.UseAuthorization();
app.MapControllers();

// Redirect root to OpenAPI documentation
app.MapGet("/", () => Results.Redirect("/openapi/v1.json"));

app.Run();
