namespace HelloWorld.Windows
open System
open System.IO
open System.Reflection
open System.Threading
open System.Windows
open Interstellar
open Interstellar.Chromium.Wpf

type App() =
    inherit Application(ShutdownMode = ShutdownMode.OnExplicitShutdown)

    override this.OnStartup e =
        base.OnStartup e
        let asmRoot = Path.GetDirectoryName (Uri(Assembly.GetEntryAssembly().CodeBase).LocalPath)
        let resources = Path.Combine (asmRoot, "Resources")
        Thread.CurrentThread.Name <- "Main"
        BrowserApp.run (HelloWorld.Interstellar.App.app resources)

module Main =
    [<EntryPoint; STAThread>]
    let main argv =
        Interstellar.Chromium.Platform.Initialize ()
        (new App()).Run ()