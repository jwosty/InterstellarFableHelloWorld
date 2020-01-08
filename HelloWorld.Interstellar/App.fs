namespace HelloWorld.Interstellar
open System
open Interstellar

module App =
    let app () = BrowserApp.openAddress (Uri("https://github.com/jwosty/Interstellar"))