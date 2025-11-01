using Marketplace.Application.Images.Commands;
using Marketplace.Application.Images.Queries;
using Marketplace.Application.Items.Commands;
using Marketplace.Application.Items.Queries;
using Marketplace.Application.ItemTypes.Queries;
using Marketplace.Application.Transfers.Commands;
using Marketplace.Application.Transfers.Queries;
using Marketplace.Application.Users.Commands;
using Marketplace.Application.Users.Queries;
using Marketplace.Domain.Interface;
using Marketplace.Infrastructure.Persistence;
using Marketplace.Infrastructure.Repositories;
using Marketplace.Infrastructure.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MarketplaceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("MarketplaceCorsPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
builder.Services.AddScoped<IItemsRepository, ItemsRepository>();
builder.Services.AddScoped<IItemTypesRepository, ItemTypesRepository>();
builder.Services.AddScoped<ITransfersRepository, TransfersRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<AddImageCommandHandler>();
builder.Services.AddScoped<DeleteImageCommandHandler>();
builder.Services.AddScoped<MakeImageFrontCommandHandler>();
builder.Services.AddScoped<GetImagesByItemQueryHandler>();
builder.Services.AddScoped<ActivateItemCommandHandler>();
builder.Services.AddScoped<AddItemCommandHandler>();
builder.Services.AddScoped<ChangeItemOwnlerCommandHandler>();
builder.Services.AddScoped<DeactivateItemCommandHandler>();
builder.Services.AddScoped<DeleteItemCommandHandler>();
builder.Services.AddScoped<UpdateItemCommandHandler>();
builder.Services.AddScoped<GetItemByIdQueryHandler>();
builder.Services.AddScoped<GetItemsBySellerQueryHandler>();
builder.Services.AddScoped<GetItemsByTypeQueryHandler>();
builder.Services.AddScoped<GetItemTypesQueryHandler>();
builder.Services.AddScoped<AddPaymentCommandHandler>();
builder.Services.AddScoped<AddWithdrawalCommandHandler>();
builder.Services.AddScoped<PurchaseItemCommandHandler>();
builder.Services.AddScoped<GetTransfersByUserQueryHandler>();
builder.Services.AddScoped<ActivateUserCommandHandler>();
builder.Services.AddScoped<AddUserCommandHandler>();
builder.Services.AddScoped<ChangeUserBalanceCommandHandler>();
builder.Services.AddScoped<DeactivateUserCommandHandler>();
builder.Services.AddScoped<RegisterUserCommandHandler>();
builder.Services.AddScoped<UpdateUserCommandHandler>();
builder.Services.AddScoped<GetAllUsersQueryHandler>();
builder.Services.AddScoped<GetUserByIdQueryHandler>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/docs");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
