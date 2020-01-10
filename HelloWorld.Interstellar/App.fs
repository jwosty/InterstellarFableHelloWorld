namespace HelloWorld.Interstellar
open System
open System.Reflection
open System.IO
open Interstellar
open Suave

module WebServer =
    open Suave.Filters
    open Suave.Operators
    
    let app : WebPart =
        choose [
            GET >=> path "/" >=> Files.file "index.html"
            GET >=> Files.browseHome
            RequestErrors.NOT_FOUND "Page not found." 
        ]
    
    let config wwwroot =
        { defaultConfig with homeFolder = Some wwwroot }
    
    let startAsync wwwroot =
        printfn "wwwroot is: %s" wwwroot
        startWebServerAsync (config wwwroot) app

module App =
    let app resourcesPath = {
        onStart = fun mainCtx createWindow -> async {
            let listening, closedHandle = WebServer.startAsync (Path.Combine (resourcesPath, "wwwroot"))
            let! closedHandle = Async.StartChild closedHandle
            let! _ = listening
            do! Async.SwitchToContext mainCtx
            let window = createWindow { BrowserWindowConfig.defaultValue with address = Some (Uri "http://localhost:8080/index.html"); showDevTools = true }
            do! window.Show ()
            do! Async.AwaitEvent window.Closed
        }
    }