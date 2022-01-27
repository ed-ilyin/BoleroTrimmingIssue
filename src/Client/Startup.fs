namespace BoleroTrimmingIssue.Client

open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Microsoft.Extensions.DependencyInjection
open System
open System.Net.Http
open Microsoft.Extensions.Configuration

module Program =

    [<EntryPoint>]
    let Main args =
        let builder = WebAssemblyHostBuilder.CreateDefault(args)
        builder.RootComponents.Add<Main.MyApp>("#main")

        builder.Services.AddScoped<HttpClient>(fun _ ->
            new HttpClient(BaseAddress = Uri builder.HostEnvironment.BaseAddress)) |> ignore

        builder.Services.AddMsalAuthentication (fun options ->
            builder.Configuration.Bind
                ("AzureAdB2C", options.ProviderOptions.Authentication)
        ) |> ignore

        builder.Build().RunAsync() |> ignore
        0
