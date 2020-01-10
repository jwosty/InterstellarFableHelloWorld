namespace HelloWorld.macOS

open AppKit
open Foundation
open System

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit NSApplicationDelegate()
