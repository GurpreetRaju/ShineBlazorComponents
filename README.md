# Shine Blazor
![](https://github.com/GurpreetRaju/ShineBlazorComponents/blob/main/ShineBlazor.Components.Demo/wwwroot/images/shine.png)

Build responsive and dynamic sites faster with Shine Blazor.

Shine Blazor library is based on [Bootstrap](https://getbootstrap.com/) css. It uses very little javascript.

### Quick Installation Guide
Install Package
```
dotnet add package ShineBlazor.Components --version 0.1.0
```
Add the following to `_Imports.razor`
```razor
@using ShineBlazor.Components
```
Add the following to the `MainLayout.razor` or `App.razor`
```razor
<ToastProvider />
```
Add the following to your HTML `head` section, it's either `index.html` or `_Layout.cshtml`/`_Host.cshtml`/`App.razor` depending on whether you're running WebAssembly or Server
```razor
<link href="_content/ShineBlazor.Components/css/shine.css" rel="stylesheet" />
```
Next, add the following to the default Blazor script at the end of the `body`
```razor
<script src="_content/ShineBlazor.Components/js/shine.js" type="text/javascript"></script>
```
If you want to use infinite scroll component also all the following script
```razor
<script src="_content/ShineBlazor.Components/InfiniteScroll.razor.js" type="module"></script>
```

Add the following to the relevant sections of `Program.cs`
```c#
using ShineBlazor.Components.Services;
```
```c#
builder.Services.AddScoped<ToastService>();
```
