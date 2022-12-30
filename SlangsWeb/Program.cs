using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SlangsWeb;
using SlangsWeb.Services;
using SlangsWeb.Services.Contracts;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7023/") });

builder.Services.AddScoped<ISlangService, SlangService>();
builder.Services.AddSpeechSynthesis();

await builder.Build().RunAsync();
