using FluentValidation;
using Services.Mapper;
using Services.Validator;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CountryMapperProfile));
builder.Services.AddValidatorsFromAssemblyContaining<PersonValidator>();
var app = builder.Build();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
