namespace HelloWorld.Interstellar
open System
open System.Reflection
open System.IO
open Interstellar

module App =
    let app () = {
        onStart = fun mainCtx createWindow -> async {
            let basePath = Assembly.GetEntryAssembly().CodeBase
            let baseUri = Uri basePath
            let indexUri = Uri ("./Content/wwwroot/index.html", UriKind.Relative)
            let uri = Uri (baseUri, indexUri)
            do! Async.SwitchToContext mainCtx
            let window = createWindow { BrowserWindowConfig.defaultValue with address = Some uri; showDevTools = true }
            do! window.Show ()
            do! Async.AwaitEvent window.Closed
        }
    }