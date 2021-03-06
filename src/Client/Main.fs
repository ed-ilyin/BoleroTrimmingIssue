module BoleroTrimmingIssue.Client.Main

open Elmish
open Bolero
open Bolero.Html
open Microsoft.AspNetCore.Components.Authorization

type Model = { x: string }
let initModel = { x = "" }
type Message = | Ping
let update message model = match message with | Ping -> model

let view model dispatch =
    comp<CascadingAuthenticationState> [] [
        comp<AuthorizeView> [
            attr.fragmentWith "Authorized" <| fun (context: AuthenticationState) ->
                div [] [text $"You're authorized! Welcome {context.User.Identity.Name}"]
            attr.fragmentWith "NotAuthorized" <| fun (_: AuthenticationState) ->
                div [] [text "You're not authorized :("]
        ] []
    ]

type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view
