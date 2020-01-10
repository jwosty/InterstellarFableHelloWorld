namespace HelloWorld.macOS

open AppKit
open System

module main =
    [<EntryPoint>]
    let main args =
        NSApplication.Init()
        NSApplication.Main(args)
        0
