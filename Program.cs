using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddMvc().AddViewLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("de"),
        new CultureInfo("fr"),
        new CultureInfo("es"),
        new CultureInfo("ru"),
        new CultureInfo("ja"),
        new CultureInfo("ar"),
        new CultureInfo("zh"),
        new CultureInfo("en-GB")
    };
    options.DefaultRequestCulture = new RequestCulture("en-GB");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>()!.Value;
app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

app.MapRazorPages();

app.Run();
