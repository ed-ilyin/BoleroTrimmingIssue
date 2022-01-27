# Bolero Trimming Issue
When I do `dotnet run —project src/Client -c Release` or `Debug` (doesn’t matter) Bolero SPA works just fine.
When I do `dotnet publish src/Client -c Release` or `Debug` (doesn’t matter) app throws:
```
blazor.webassembly.js:1

       crit: Microsoft.AspNetCore.Components.WebAssembly.Rendering.WebAssemblyRenderer[100]
      Unhandled exception rendering component: Arg_NoDefCTor, Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState
System.MissingMethodException: Arg_NoDefCTor, Microsoft.AspNetCore.Components.Authorization.CascadingAuthenticationState
   at System.RuntimeType.CreateInstanceMono(Boolean , Boolean )
```
Why publishing stops app from functioning?
## Created using minimal SPA template
`dotnet new bolero-app -o BoleroTrimmingIssue --minimal=true --server=false`
## To reproduce the issue
`cd BoleroTrimmingIssue`

`dotnet publish src/Client -c Release`

`swa start ./src/Client/bin/Release/net6.0/publish/wwwroot`
or any other kind of serving static files
