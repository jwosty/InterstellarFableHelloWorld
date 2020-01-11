namespace HelloWorld.macOS
open System
open AppKit
open Foundation
open Interstellar
open Interstellar.MacOS.WebKit

[<Register("AppDelegate")>]
type AppDelegate() =
    inherit NSApplicationDelegate()
    
    override this.DidFinishLaunching notification =
        let app = HelloWorld.Interstellar.App.app NSBundle.MainBundle.ResourcePath
        BrowserApp.run app