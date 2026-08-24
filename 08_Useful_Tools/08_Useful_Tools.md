---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
marp: true
---

<style>
    @import url('../styles/presentation-styles.css');

    .container {
        display: flex;
    }

    .col {
        flex: 1
    }

    .col-3 {
        flex: 3
    }

    .col-2 {
        flex: 2
    }

    img[alt~="center"] {
    display: block;
    margin: 0 auto;
    max-width: 100%;
    max-height: 400px;
    object-fit: contain;
    }

    section.demo h1 {
        text-align: center;
        margin: 180px;
        font-size: 80px;
        color: rgb(132, 168, 196)
}
</style>

# PV239 – Bonus 2 - Useful Tools

---

## Debugging

- XAML Binding Failures
    - Displays failuers in bindings – also in runtime
- Device Log
    - Displaying log directly from a device
    - Enables filtering
    - Available for Android and iOS
- Output
    - If you can’t see error elsewhere – try to look into Output
    - Sometimes you encounter error from native code – at least you know what to search for

---

<!-- _class: demo -->
## Debugging

# DEMO

---

## Extensions

- Resharper
    - Much better IntelliSense in XAML
    - Refactoring, code navigation…
    - Performance can get bad – especially with larger solutions

- XAML Styler
    - Automatic formatting for XAML files
    - Can change order of attributes, clean up spacing…
    - Very customizable – look into options and see what is available
    - Can run as CLI tool
    - Can be set up as part of GIT Prehook (no more wrong formatted commits)

---

<!-- _class: demo -->
## Extensions

# DEMO

---

## Configuration

- Add json file (i.e. **appsettings.json**) as Embedded Resource
- Add Nuget packages
    - `Microsoft.Extensions.Configuration.Binder`
    - `Microsoft.Extensions.Configuration.Json`
- Add the file stream to ConfigurationBuilder
    - `AddJsonStream()`
- Configure the section for IOptions
    - `builder.Configure<ApiOptions>(o => builder.Configuration.GetSection(“ApiOptions”)).Bind(options));`
- Resolve `IOptions<ApiOptions>` where needed

---

<!-- _class: demo -->
## Configuration

# DEMO

---
## Platform Specific – OnPlatform, OnIdiom

- Useful in XAML
- OnPlatform – specify different value for different platforms (Android, iOS, MacCatalyst, Tizen, WinUI)
- OnIdiom – specify different value for different idioms (Phone, Tablet, Desktop, TV, Watch)
---

<!-- _class: demo -->
## OnPlatform, OnIdiom

# DEMO

---

## Local API

- Emulator - **10.0.2.2** - loopback address to host machine
- Visual Studio -  [Dev Tunnels](https://learn.microsoft.com/en-us/aspnet/core/test/dev-tunnels)
- CLI - ngrok

---

<!-- _class: demo -->
## Visual Studio Dev Tunnles

# DEMO

---

## Global XAML namespaces

- Don't write XAML namespaces anymore!
- In C# define namespaces that are globally available:
```csharp
[assembly: XmlnsDefinition("http://schemas.microsoft.com/dotnet/maui/global", "CookBook.Maui.Pages.Base")]
```
- In XAML use the **http://schemas.microsoft.com/dotnet/maui/global** value as **xmlns**:

```xml
<ContentPageBase xmlns="http://schemas.microsoft.com/dotnet/maui/global" ... />
```