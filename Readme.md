# Interstellar+Fable Hello World

This is a standalone application that integrates [Interstellar](https://github.com/jwosty/Interstellar) and [Fable](https://fable.io/). It's analagous to using [Electron](https://electronjs.org), except that it employs F# for the whole stack instead of Javascript. This app features a simple GUI built with [Elmish-React](https://elmish.github.io/react/). This can be run using Visual Studio just like any other application.

Here are the interesting bits to look at:

* [HelloWorld.FableUI/FableApp.fs](HelloWorld.FableUI/FableApp.fs) - the Fable+Elmish+React UI, written in F# and transpiled to Javascript
* [HelloWorld.Interstellar/App.fs](HelloWorld.Interstellar/App.fs) - the Interstellar BrowserApp definition, which handles the lifecycle of the windows, and also hosts and simple static file server for the transpiled Javascript
* [HelloWorld.Windows/HelloWorld.Windows.fsproj](HelloWorld.Windows/HelloWorld.Windows.fsproj) - the Windows entry point
* [HelloWorld.macOS/AppDelegate.fs](HelloWorld.macOS/AppDelegate.fs) - the macOS entry point

## Running
On Windows, open HelloWorld.Windows.sln and run. On macOS, open HelloWorld.macOS.sln, but make sure to execute `yarn install` in the command line before running the solution.
