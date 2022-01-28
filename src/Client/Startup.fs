namespace BoleroTrimmingIssue.Client

open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Microsoft.Extensions.DependencyInjection
open System
open System.Net.Http
open Microsoft.Extensions.Configuration
open Microsoft.AspNetCore.Components.Authorization
open Microsoft.AspNetCore.Components.WebAssembly.Hosting
open Microsoft.Extensions.DependencyInjection
open System.Security.Claims
open System.Threading.Tasks

type DummyAuthProvider() =
    inherit AuthenticationStateProvider()

    override _.GetAuthenticationStateAsync() =
        let identity = ClaimsIdentity([|Claim(ClaimTypes.Name, "loic")|], "Fake auth type")
        let user = ClaimsPrincipal(identity)
        Task.FromResult(AuthenticationState(user))

module Program =

    [<EntryPoint>]
    let Main args =
        let builder = WebAssemblyHostBuilder.CreateDefault(args)
        builder.RootComponents.Add<Main.MyApp>("#main")

        builder.Services.AddScoped<HttpClient>(fun _ ->
            new HttpClient(BaseAddress = Uri builder.HostEnvironment.BaseAddress)) |> ignore

        // builder.Services.AddMsalAuthentication (fun options ->
        //     builder.Configuration.Bind
        //         ("AzureAdB2C", options.ProviderOptions.Authentication)
        // ) |> ignore
        builder.Services.AddScoped<AuthenticationStateProvider, DummyAuthProvider>() |> ignore
        builder.Services.AddAuthorizationCore() |> ignore

        builder.Build().RunAsync() |> ignore
        0
