﻿using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Interfaces.Services;
using accountingwebapi.Models.App;
using accountingwebapi.Services;
using accountingwebapi.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using POSIMSWebApi.Interceptors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); // <-- Swagger service

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Accounting Web Api";
    config.Description = "API documentation for Accounting Web Api using NSwag.";
    config.Version = "v1";

});


//CONTEXT
builder.Services.AddDbContext<AcctgContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"), npgsqlOptions =>
        npgsqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorCodesToAdd: null
        )));

//AUDITING
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuditInterceptor>();


//SERVICES
builder.Services.AddHttpClient(); // ✅ Needed for IHttpClientFactory
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISubAccountService, SubAccountService>();
builder.Services.AddScoped<IIndividualAccountService, IndividualAccountService>();
builder.Services.AddScoped<IJournalEntryService, JournalEntryService>();
builder.Services.AddScoped<IAccountingPeriodService, AccountingPeriodService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEntryTemplateService, EntryTemplateService>();
builder.Services.AddScoped<IEntryTemplateUsageStatsService, EntryTemplateUsageStatsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    //app.UseOpenApi();    
    //app.UseReDoc();
    app.UseSwagger();        
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
