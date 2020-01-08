namespace HelloWorld.Windows
open System
open System.Windows
open System.Threading
open Interstellar
open Interstellar.Chromium.Wpf
open HelloWorld.Interstellar

type App() =
    inherit Application(ShutdownMode = ShutdownMode.OnExplicitShutdown)

    override this.OnStartup e =
        base.OnStartup e
        BrowserApp.run (HelloWorld.Interstellar.App.app ())

module Main =
    [<EntryPoint; STAThread>]
    let main argv =
        Thread.CurrentThread.Name <- "Main"
        Interstellar.Chromium.Platform.Initialize ()
        (new App()).Run ()