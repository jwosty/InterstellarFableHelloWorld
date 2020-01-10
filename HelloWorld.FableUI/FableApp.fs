namespace HelloWorld.FableUI
open System
open Elmish
open Fable

module App =
    //open Elmish.React
    open Fable.React
    open Fable.React.Props
    
    type App = { counter: int }
    
    type Msg = Set of int | Inc | Dec

    let init () = { counter = 0 }, Cmd.none

    let update msg app =
        match msg with
        | Set value -> { app with counter = value }, Cmd.none
        | Inc -> { app with counter = app.counter + 1 }, Cmd.none
        | Dec -> { app with counter = app.counter - 1 }, Cmd.none

    let view app dispatch =
        div [] [
            str (sprintf "Counter: %d" app.counter)
            br []
            input [Type "button"; Value "+"; OnClick (fun _ -> dispatch Inc)]
            input [Type "button"; Value "-"; OnClick (fun _ -> dispatch Dec)]
            input [Type "button"; Value "Reset"; OnClick (fun _ -> dispatch (Set 0))]
        ]

module Main =
    open Elmish.React

    [<EntryPoint>]
    let main _ =
        try
            Program.mkProgram App.init App.update App.view
            |> Program.withReactSynchronous "elmish-app"
            |> Program.runWith ()
            0
        with e ->
            eprintfn "Failed to start app: %A" e
            1