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

# PV239 – Using AI in .NET MAUI Development
<!-- _paginate: skip -->

---

## MAUI Sherpa

- App with useful tools for environment setup and app development
- Doctor - check environment setup (currently available in version 0.7.0)
- Manage Android and iOS related settings - SDKs, keystore, Bundle IDs, certificates, provisioning profiles, secrets, pub
- Send push notifications - Firebase, APNs
- Android SDK packages - check installed tools and versions
- https://github.com/Redth/MAUI.Sherpa
- Download from GitHub **Releases**

---

## MAUI Sherpa - Devices

- See connected devices
- Access logs
- Access file system
- Connect to adb shell
- Capture screenshots and screen recordings
- Send deep links
- Manage installed apps

---

## MAUI Sherpa - App Inspector

- Visual tree
- Network
- Profiling
- WebView
- Logs
- Platform information

---

## MAUI DevFlow

- Tool for automating and debugging .NET MAUI apps
- Built to enable AI agents to build, deploy, inspect and debug MAUI apps from terminal
- Used in MAUI Sherpa - App Inspector
- https://github.com/Redth/MauiDevFlow

---

## MAUI DevFlow - install
- Install as dotnet tool:
```sh
dotnet tool install --global Redth.MauiDevFlow.CLI

dotnet tool install --global androidsdk.tool    # android (SDK, AVD, device management)

dotnet tool install --global appledev.tools     # apple (simulators, provisioning, certificates)
```

---

## MAUI DevFlow - app setup

- Add nuget package `Redth.MauiDevFlow.Agent`
- Configure MauiProgram.cs
```csharp
#if DEBUG
builder.AddMauiDevFlowAgent();
#endif
```

---

## MAUI DevFlow - tools

- maui_screenshot - capture screenshot
- maui_tree - visual tree as structured JSON
- maui_tap - tap a UI element by ID
- maui_fill - fill text into an Entry/Editor/SearchBar
- maui_scroll - scroll a ScrollView (by delta, item index, or position)
- maui_navigate - navigate to a Shell route
- ...
- Complete list: https://github.com/Redth/MauiDevFlow?tab=readme-ov-file#available-tools

---

## GitHub Copilot CLI

- One of the clients for GitHub Copilot
- /model - Choose model based on use-case (OpenAI, Anthropic, Google, xAI...)

---

## GitHub Copilot CLI - MCP Servers

- /mcp - add and select active MCP servers
- "Normal" information cap can be about a year old - old .NET versions, old code practices etc.
- Microsoft Learn MCP Server - https://learn.microsoft.com/en-us/training/support/mcp
- MAUI DevFlow MCP Server - https://github.com/Redth/MauiDevFlow?tab=readme-ov-file#mcp-server

---

## GitHub Copilot CLI - usage

- /plan - create a plan
    - Run first before running the actual work
    - Save the plan file somewhere - to review it and be able to access it in the future
    - Make sure there are verify steps
- autopilot - executes the plan autonomously
- /yolo on - enable all permissions - use at your own discretion

---

## GitHub Copilot CLI - Custom skills
- /skills
    - Create custom skills
    - i.e. how to create a page (create page, VM, register it in Shell...)
    - Don't load too many skills into a single session - context window is small
    - **maui_ai_debugging** skill from MAUI DevFlow - describe what you want to debug and it will do it - clicking, filling texts, navigating etc.

---

## Polypilot

- Multi-agent control plane for GitHubt Copilot
- Useful with GIT worktree - separate checkouts for separate branches, multiple tasks running simultaneously locally
- Alternatively use 
- Can be accessed from mobile - see current status of sessions, send commands etc.
- https://github.com/PureWeen/PolyPilot

---

## VS Code integration

- Add .vscode/mcp.json file
```json
{
   "servers": {
     "maui-devflow": {
       "type": "stdio",
       "command": "maui-devflow",
       "args": ["mcp-serve"]
     }
   }
}
```

---

## Punk

- Many of these tools didn't exist at the beginning of this semester
- This all is changing rapidly
- It will accelerate even faster
- Sample code: https://github.com/jasho/chatr