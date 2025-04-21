using CA_FrameworksDrivers_ExternalService;
using CA_InterfaceAdapters_Adapters;
using CA_InterfaceAdapters_Adapters.Dtos;
using CA_InterfaceAdapters_Mappers;
using CA_InterfaceAdapters_Mappers.Dtos.Requests;
using CL_ApplicationLayer;
using CL_EnterpriseLayer;
using CL_FrameworksDrivers_API.Middlewares;
using CL_FrameworksDrivers_API.Validators;
using CL_InterfaceAdapters;
using CL_InterfaceAdapters_Data;
using CL_InterfaceAdapters_Models;
using CL_InterfaceAdapters_Presenters;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// validators
builder.Services.AddValidatorsFromAssemblyContaining<BeerValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// dependencias
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<GetBeerUseCase<Beer, BeerViewModel>>();
builder.Services.AddScoped<GetBeerUseCase<Beer, BeerDetailViewModel>>();
builder.Services.AddScoped<AddBeerUseCase<BeerRequestDTO>>();
builder.Services.AddScoped<GetPostUseCase>();
builder.Services.AddScoped<GenerateSaleUseCase<SaleRequestDTO>>();
builder.Services.AddScoped<GetSaleUseCase>();
builder.Services.AddScoped<GetSaleSearchUseCase<SaleModel>>();
builder.Services.AddScoped<IRepository<Beer>, Repository>();
builder.Services.AddScoped<IRepository<Sale>, SaleRepository>();
builder.Services.AddScoped<IRepositorySearch<SaleModel, Sale>, SaleRepository>();
builder.Services.AddScoped<IPresenter<Beer, BeerViewModel>, BeerPresenter>();
builder.Services.AddScoped<IPresenter<Beer, BeerDetailViewModel>, BeerDetailPresenter>();
builder.Services.AddScoped<IMapper<BeerRequestDTO, Beer>, BeerMapper>();
builder.Services.AddScoped<IMapper<SaleRequestDTO, Sale>, SaleMapper>();
builder.Services.AddScoped<IExternalService<PostServiceDto>, PostService>();
builder.Services.AddScoped<IExternalServiceAdapter<Post>, PostExternalServiceAdapter>();


builder.Services.AddHttpClient<IExternalService<PostServiceDto>, PostService>(c => {
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"]);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseMiddleware<ExceptionMiddleware>();


app.MapGet("/beer", async (GetBeerUseCase<Beer, BeerViewModel> beerUseCase) =>
{ 
    return await beerUseCase.ExecuteAsync();
})
.WithName("beers")
.WithOpenApi();

app.MapPost("/beer", async (BeerRequestDTO beerRequest,
    AddBeerUseCase<BeerRequestDTO> beerUseCase, 
    IValidator<BeerRequestDTO> validator) =>
{
    var result = await validator.ValidateAsync(beerRequest);

    if (!result.IsValid)
    {
        return Results.ValidationProblem(result.ToDictionary());
    }

    await beerUseCase.ExecuteAsync(beerRequest);
    return Results.Created();
})
.WithName("addBeer")
.WithOpenApi();


app.MapGet("/beerDetail", async (GetBeerUseCase<Beer, BeerDetailViewModel> beerUseCase) =>
{
    return await beerUseCase.ExecuteAsync();
})
.WithName("beerDetail")
.WithOpenApi();

app.MapGet("/posts", async (GetPostUseCase postUseCase) =>
{
    return await postUseCase.ExecuteAsync();
})
.WithName("posts")
.WithOpenApi();

app.MapPost("/sale", async (SaleRequestDTO saleRequest,
    GenerateSaleUseCase<SaleRequestDTO> saleUseCase) =>
{
    await saleUseCase.ExecuteAsync(saleRequest);
    return Results.Created();
})
.WithName("generateSale")
.WithOpenApi();

app.MapGet("/sale", async (GetSaleUseCase saleUseCase) =>
{
    return await saleUseCase.ExecuteAsync();
})
.WithName("getSales")
.WithOpenApi();

app.MapGet("/salesearch/{total}", async (GetSaleSearchUseCase<SaleModel> saleUseCase,
    int total) =>
{
    return await saleUseCase.ExecuteAsync(s => s.Total>total);
})
.WithName("getSalesSearch")
.WithOpenApi();


app.Run();

