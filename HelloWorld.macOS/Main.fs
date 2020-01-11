namespace HelloWorld.macOS
open System
open System.Threading
open AppKit

module main =
    [<EntryPoint>]
    let main args =
        Thread.CurrentThread.Name <- "Main"
        NSApplication.Init()
        NSApplication.SharedApplication.Delegate <- new AppDelegate()
        NSApplication.Main(args)
        0