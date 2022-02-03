# Bolero Trimming Issue
When I do `dotnet run —project src/Client -c Release` or `Debug` (doesn’t matter) Bolero SPA works just fine.
When I do `dotnet publish src/Client -c Release` or `Debug` (doesn’t matter) app throws:
```
Uncaught (in promise) Error: Invalid JS call result type '3'.
    at _ (blazor.webassembly.js:1:4820)
    at blazor.webassembly.js:1:4045
```
Why publishing stops app from functioning?
## Created using minimal SPA template
`dotnet new bolero-app -o BoleroTrimmingIssue --minimal=true --server=false`
## To reproduce the issue
`cd BoleroTrimmingIssue`

`dotnet publish src/Client -c Release`

`swa start ./src/Client/bin/Release/net6.0/publish/wwwroot`
or any other kind of serving static files
